using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string? FullName { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public ICollection<Company>? Companies { get; set; } = new List<Company>();
        public string? BasketId { get; set; }
        public Basket? Basket { get; set; }

    }
}
