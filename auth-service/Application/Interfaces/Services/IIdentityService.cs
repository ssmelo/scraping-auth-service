using auth_service.Application.DTOs.User.Login;
using auth_service.Application.DTOs.User.Register;
using auth_service.Domain.Models;

namespace auth_service.Application.Interfaces.Services
{
    public interface IIdentityService
    {
        public Task<User> RegisterUser(RegisterUserRequestDTO userRequestDTO);

        public Task<LoginResponseBody> Login(LoginRequestDTO loginRequestDTO);
    }
}
