using System.ComponentModel.DataAnnotations;

namespace auth_service.Application.DTOs.User.Register
{
    public record RegisterUserRequestDTO
    {
        [Required]
        public string FirstName { get; init; }

        [Required]
        public string LastName { get; init; }

        [Required]
        public string Email { get; init; }

        [Required]
        public string Password { get; init; }

        [Required]
        public string ConfirmPassword { get; init; }

    }
}
