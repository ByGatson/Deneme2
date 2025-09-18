using Domain.Entities;

namespace Application.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        public Task<List<Product>> GetAllByIdAsync(string Id);
        public Task<Product> GetByIdAsync(string Id);
    }
}
