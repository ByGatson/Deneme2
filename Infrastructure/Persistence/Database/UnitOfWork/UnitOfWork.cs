using Application.Repositories;
using Application.UnitOfWork;
using Persistence.Database.Context;

namespace Persistence.Database.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public ECommerceDbContext _context;
        private readonly ICompanyRepository _companyRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        public ICompanyRepository CompanyRepository => _companyRepository;
        public ICustomerRepository CustomerRepository => _customerRepository;
        public IProductRepository ProductRepository => _productRepository;
        public UnitOfWork(ECommerceDbContext context, ICompanyRepository companyRepository, ICustomerRepository customerRepository, IProductRepository productRepository)
        {
            _context = context;
            _companyRepository = companyRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }


        public void Dispose() => _context.Dispose();
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken) => await _context.SaveChangesAsync();
    }
}
