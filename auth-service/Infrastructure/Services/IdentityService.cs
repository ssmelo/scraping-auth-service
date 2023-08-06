using auth_service.Application.DTOs.User.Login;
using auth_service.Application.DTOs.User.Register;
using auth_service.Application.Interfaces.Services;
using auth_service.Domain.Errors;
using auth_service.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace auth_service.Infrastructure
{
    public class IdentityService : IIdentityService
    {
        private readonly SignInManager<User> _signManager;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public IdentityService(SignInManager<User> signInManager, UserManager<User> userManager, IMapper mapper, IConfiguration config) 
        {
            _signManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
            _config = config;
        }

        public async Task<LoginResponseBody> Login(LoginRequestDTO loginRequestDTO)
        {
            var result = await _signManager.PasswordSignInAsync(loginRequestDTO.Email, loginRequestDTO.Password, false, false);
            if(!result.Succeeded)
            {
                ThreatLoginFailures(result);
            }

            var token = GetToken(new List<Claim>());

            return new LoginResponseBody(new JwtSecurityTokenHandler().WriteToken(token), token.ValidTo);
        }

        public async Task<User> RegisterUser(RegisterUserRequestDTO userRequestDTO)
        {
            var user = _mapper.Map<User>(userRequestDTO);

            var result = await _userManager.CreateAsync(user, userRequestDTO.Password);

            if(!result.Succeeded)
            {
                var errors = result.Errors.Select(error => error.Description).ToList();
                throw new DefaultException(400, "User registration could not be executed", errors);
            }

            await _userManager.SetLockoutEnabledAsync(user, false);

            return user;
        }

        private void ThreatLoginFailures(SignInResult singInResult)
        {
            if (singInResult.IsNotAllowed)
                throw new BaseException(400, "Account not allowed to perform login");
            else if (singInResult.IsLockedOut)
                throw new BaseException(400, "Account is blocked");
            else if (singInResult.RequiresTwoFactor)
                throw new BaseException(400, "Account requires a two factor authentication");
            else
                throw new BaseException(400, "User or password are wrong");
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Authentication:SigningKey"]));

            var token = new JwtSecurityToken(
                issuer: _config["Authentication:ValidIssuer"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
