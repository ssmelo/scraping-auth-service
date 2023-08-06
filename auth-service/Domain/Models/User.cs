using Microsoft.AspNetCore.Identity;

namespace auth_service.Domain.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
