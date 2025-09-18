using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Persistence.Database.Context;

namespace Persistence.Database.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly ECommerceDbContext _context;

        public BasketRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> AddProductToBasket(string basketId, Product product)
        {
            var basket = await _context.Baskets.FindAsync(basketId);
            if (basket is not null)
                basket.Products.Add(product);
            return (List<Product>)basket.Products;
        }
        public async Task<EntityEntry<Basket>> AddAsync(Basket basket) => await _context.Baskets.AddAsync(basket);
    }
}
