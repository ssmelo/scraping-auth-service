using System.ComponentModel.DataAnnotations;

namespace auth_service.Application.DTOs.User.Login
{
    public record LoginRequestDTO
    {
        [Required]
        public string Email { get; init; }

        [Required]
        public string Password { get; init; }
    }
}
