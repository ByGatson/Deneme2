using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Auth
{
    public class AppUser : IdentityUser<string>
    {
        public string? FullName { get; set; }
        public string? CompanyId { get; set; }
        public Company? Company { get; set; }
    }
}
