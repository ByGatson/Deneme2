using Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Application.Repositories
{
    public interface IBasketRepository
    {
        Task<List<Product>> AddProductToBasket(string basketId, Product product);
        Task<EntityEntry<Basket>> AddAsync(Basket basket);

    }
}
