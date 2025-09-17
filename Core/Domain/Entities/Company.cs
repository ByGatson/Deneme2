using Domain.Entities.Auth;
using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Company : BaseEntity
    {
        public string CompanyName { get; set; } = string.Empty;
        public string CompanyAddress { get; set; } = string.Empty;
        public string? UserId { get; set; }
        public AppUser User { get; set; }
        public ICollection<Customer> Customers { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
