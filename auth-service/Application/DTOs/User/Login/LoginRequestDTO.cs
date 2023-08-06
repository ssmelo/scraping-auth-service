using System.ComponentModel.DataAnnotations;

namespace auth_service.Application.DTOs.User.Login
{
    public class LoginRequestDTO
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public LoginRequestDTO(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
