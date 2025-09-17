using Application.UnitOfWork;
using MediatR;

namespace Application.Features.Product.Request.GetAllById
{
    public class GetAllByIdProductRequestHandler : IRequestHandler<GetAllByIdProductRequest, List<Domain.Entities.Product>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllByIdProductRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Domain.Entities.Product>> Handle(GetAllByIdProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.GetAllByIdAsync(request.Id);
            return product;
        }
    }
}
