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
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBasketRepository _basketRepository;
        public ICompanyRepository CompanyRepository => _companyRepository;
        public ICustomerRepository CustomerRepository => _customerRepository;
        public IProductRepository ProductRepository => _productRepository;

        public IBasketRepository BasketRepository => _basketRepository;

        public ICategoryRepository CategoryRepository => _categoryRepository;

        public UnitOfWork(ECommerceDbContext context, ICompanyRepository companyRepository, ICustomerRepository customerRepository, IProductRepository productRepository, ICategoryRepository categoryRepository, IBasketRepository basketRepository)
        {
            _context = context;
            _companyRepository = companyRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _basketRepository = basketRepository;
        }


        public void Dispose() => _context.Dispose();
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken) => await _context.SaveChangesAsync();
    }
}
