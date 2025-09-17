using Domain.Entities.Auth;
using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Basket : BaseEntity
    {
        public ICollection<Product>? Products { get; set; } = new List<Product>();
        public string? UserId { get; set; }
        public AppUser? AppUser { get; set; }
        public string? CompanyId { get; set; }
        public Company? Company { get; set; }
    }
}
