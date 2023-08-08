namespace auth_service.Application.DTOs.User.Login
{
    public record LoginResponseBody(string Token, DateTime Expiration);
}
