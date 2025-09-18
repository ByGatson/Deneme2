using Application.Interfaces.Redis;
using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Database.Context;
using Persistence.Database.Repositories.Common;

namespace Persistence.Database.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ECommerceDbContext _context;
        private readonly ICacheService _redis;
        public CategoryRepository(ECommerceDbContext context, ICacheService redis) : base(context)
        {
            _context = context;
            _redis = redis;
        }

        public async override Task<List<Category>> GetAll()
        {
            var companyId = await _redis.GetAsync("companyId");
            if (companyId is null) throw new KeyNotFoundException("CompanyID not found");
            var categories = await _context.Categories.Where(c => c.CompanyId == companyId).ToListAsync();
            if (categories is null) return new List<Category>();
            return categories;
        }
    }
}
