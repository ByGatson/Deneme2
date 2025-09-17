using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public string FullName { get; set; }
        public string Price { get; set; }
        public string CompanyId { get; set; }
        public Company Company { get; set; }

    }
}
