using auth_service.Application.DTOs.User;
using auth_service.Application.DTOs.User.Login;
using auth_service.Application.DTOs.User.Register;
using auth_service.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace auth_service.Api
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public UserController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequestDTO userRequestDTO)
        {
            var result = await _identityService.RegisterUser(userRequestDTO);

            return CreatedAtAction(
                "RegisterUser",
                new RegisterUserResponseDTO(201, new RegisterUserResponseBody(result.Email, result.FirstName))
            );
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
        {
            var result = await _identityService.Login(loginRequestDTO);

            return CreatedAtAction(
                "Login",
                new LoginResponseDTO(200, result)
            );
        }
    }
}
