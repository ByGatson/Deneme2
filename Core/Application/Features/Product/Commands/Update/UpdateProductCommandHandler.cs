using Application.Exceptions;
using Application.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Commands.Update
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.FindByIdAsync(request.Id);
            if (product is null)
                throw new EntityIsNotFoundException("Product bulunamadı");

            _mapper.Map(request, product);

            _unitOfWork.ProductRepository.Update(product);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            return result > 0;
        }
    }
}
