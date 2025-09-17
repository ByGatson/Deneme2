using Application.Interfaces.Redis;
using Application.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Commands.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICacheService _redis;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ICacheService redis)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _redis = redis;
        }

        public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Domain.Entities.Product>(request);
            product.CompanyId = await _redis.GetAsync("companyId");
            await _unitOfWork.ProductRepository.AddAsync(product);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            return result > 0;
        }
    }
}
