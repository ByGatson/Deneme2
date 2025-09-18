using Application.Repositories;

namespace Application.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public ICompanyRepository CompanyRepository { get; }
        public ICustomerRepository CustomerRepository { get; }
        public IProductRepository ProductRepository { get; }
        public IBasketRepository BasketRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
