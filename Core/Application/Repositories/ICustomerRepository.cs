using Domain.Entities;

namespace Application.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        public Task<List<Customer>> GetAllByIdAsync(string id);
    }
}
