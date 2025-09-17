using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Database.Context;
using Persistence.Database.Repositories.Common;

namespace Persistence.Database.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly ECommerceDbContext _context;
        public CompanyRepository(ECommerceDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Company>> GetAllByIdAsync(string userId)
        {
            var result = await _context.Companies.Where(c => c.UserId == userId).ToListAsync();
            return result;
        }

    }
}
