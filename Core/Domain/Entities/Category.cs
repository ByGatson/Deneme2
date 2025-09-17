using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Category : BaseEntity
    {
        public string? CategoryName { get; set; } = string.Empty;
        public ICollection<Product>? Products { get; set; } = new List<Product>();
        public string? CompanyId { get; set; }
        public Company? Company { get; set; }
    }
}
