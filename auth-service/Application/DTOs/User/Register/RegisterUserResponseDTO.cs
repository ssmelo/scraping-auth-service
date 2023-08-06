namespace auth_service.Application.DTOs.User.Register
{
    public class RegisterUserResponseDTO : BaseResponse<RegisterUserResponseBody>
    {
        public RegisterUserResponseDTO(int code, RegisterUserResponseBody data) : base(code, data)
        {
        }
    }
}
