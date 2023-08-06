namespace auth_service.Application.DTOs.User.Register
{
    public class RegisterUserResponseBody
    {
        public string Email { get; set; }
        public string FirstName { get; set; }

        public RegisterUserResponseBody(string email, string firstName)
        {
            Email = email;
            FirstName = firstName;
        }
    }
}