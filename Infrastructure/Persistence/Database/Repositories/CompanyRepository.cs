using Application.Interfaces.Redis;
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
        private readonly ICacheService _redis;
        public CompanyRepository(ECommerceDbContext context, ICacheService redis) : base(context)
        {
            _context = context;
            _redis = redis;
        }

        public override async Task<List<Company>> GetAll()
        {
            var userId = await _redis.GetAsync("userId");
            if (userId is null)
                throw new NotImplementedException();
            var result = await GetAllByUserIdAsync(userId);
            return result;
        }

        public async Task<List<Company>> GetAllByUserIdAsync(string userId)
        {
            var result = await _context.Companies.Where(c => c.UserId == userId).ToListAsync();
            return result;
        }

    }
}
