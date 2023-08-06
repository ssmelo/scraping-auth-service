namespace auth_service.Application.DTOs.User.Login
{
    public class LoginResponseDTO : BaseResponse<LoginResponseBody>
    {
        public LoginResponseDTO(int code, LoginResponseBody data) : base(code, data)
        {
        }
    }
}
