using Application.Interfaces.Redis;
using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Database.Context;
using Persistence.Database.Repositories.Common;

namespace Persistence.Database.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly ECommerceDbContext _context;
        private readonly ICacheService _redis;
        public CustomerRepository(ECommerceDbContext context, ICacheService redis) : base(context)
        {
            _context = context;
            _redis = redis;
        }

        public async override Task<List<Customer>> GetAll()
        {
            var companyId = await _redis.GetAsync("companyId");
            if (companyId is null)
                return new List<Customer>();

            var customers = await _context.Customers
                .Where(c => c.Companies!.Any(co => co.Id == companyId))
                .Include(c => c.Companies)
                .ToListAsync();

            return customers;
        }

        public async Task<List<Customer>> GetAllByIdAsync(string id)
        {
            var result = await _context.Customers.Where(c => c.Id == id).ToListAsync();
            return result;
        }
    }
}
