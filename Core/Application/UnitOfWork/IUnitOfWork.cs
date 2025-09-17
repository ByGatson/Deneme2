using Application.Repositories;

namespace Application.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public ICompanyRepository CompanyRepository { get; }
        public ICustomerRepository CustomerRepository { get; }
        public IProductRepository ProductRepository { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
