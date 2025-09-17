using Application.UnitOfWork;
using MediatR;

namespace Application.Features.Product.Request.GetAll
{
    public class GetAllProductRequestHandler : IRequestHandler<GetAllProductRequest, List<Domain.Entities.Product>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllProductRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Domain.Entities.Product>> Handle(GetAllProductRequest request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.ProductRepository.GetAll();
            return products;
        }
    }
}
