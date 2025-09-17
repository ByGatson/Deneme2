using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public string? ProductName { get; set; }
        public string? Price { get; set; }
        public string? CompanyId { get; set; }
        public Company? Company { get; set; }
        public string? CategoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<Basket> Baskets { get; set; } = new List<Basket>();
    }
}
