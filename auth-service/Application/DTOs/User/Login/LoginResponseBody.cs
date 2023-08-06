namespace auth_service.Application.DTOs.User.Login
{
    public class LoginResponseBody
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }

        public LoginResponseBody(string token, DateTime expiration)
        {
            Token = token;
            Expiration = expiration;
        }
    }
}
