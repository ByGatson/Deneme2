using Domain.Entities;

namespace Application.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        public Task<List<Product>> GetAllByIdAsync(string Id);
    }
}
