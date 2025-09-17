using Application.Interfaces.Redis;
using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Database.Context;
using Persistence.Database.Repositories.Common;

namespace Persistence.Database.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ECommerceDbContext _context;
        private readonly ICacheService _redis;
        public ProductRepository(ECommerceDbContext context, ICacheService redis) : base(context)
        {
            _context = context;
            _redis = redis;
        }

        public override async Task<List<Product>> GetAll()
        {
            var companyId = await _redis.GetAsync("companyId");
            if (companyId is null)
                return new List<Product>();

            var products = await _context.Products
                .Where(p => p.CompanyId == companyId)
                .Include(p => p.Category)
                .Include(p => p.Company)
                .ToListAsync();

            return products;
        }

        public async Task<List<Product>> GetAllByIdAsync(string id)
        {
            var result = await _context.Products.Where(c => c.Id == id).ToListAsync();
            return result;
        }
    }
}
