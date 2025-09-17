using Domain.Entities;

namespace Application.Repositories
{
    public interface ICompanyRepository : IRepository<Company>
    {
        public Task<List<Company>> GetAllByIdAsync(string userId);
    }
}
