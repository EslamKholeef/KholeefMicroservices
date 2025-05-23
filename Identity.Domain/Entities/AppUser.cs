using Microsoft.AspNetCore.Identity;

namespace Identity.Domain.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
