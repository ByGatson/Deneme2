using Domain.Entities.Auth;
using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Company : BaseEntity
    {
        public string? CompanyName { get; set; }
        public string? CompanyAddress { get; set; }
        public string? UserId { get; set; }
        public AppUser? User { get; set; }
        public ICollection<Customer>? Customers { get; set; } = new List<Customer>();
        public ICollection<Product>? Products { get; set; } = new List<Product>();
        public ICollection<Category>? Categories { get; set; } = new List<Category>();
        public ICollection<Basket>? Baskets { get; set; } = new List<Basket>();

    }
}
