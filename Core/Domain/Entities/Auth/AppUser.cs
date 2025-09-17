using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Auth
{
    public class AppUser : IdentityUser<string>
    {
        public string FullName { get; set; } = string.Empty;
        public ICollection<Company> Companies { get; set; }
    }
}
