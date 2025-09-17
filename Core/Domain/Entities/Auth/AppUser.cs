using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Auth
{
    public class AppUser : IdentityUser<string>
    {
        public string? FullName { get; set; } = string.Empty;
        public string? CompanyId { get; set; } = string.Empty;
        public Company? Company { get; set; }
    }
}
