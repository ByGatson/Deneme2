using Application.Exceptions;
using Application.UnitOfWork;
using MediatR;

namespace Application.Features.Product.Commands.Delete
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {

        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.FindByIdAsync(request.Id);
            if (product is null)
                throw new EntityIsNotFoundException("Product bulunamadı");

            await _unitOfWork.ProductRepository.RemoveAsync(request.Id);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            return result > 0;
        }
    }
}
