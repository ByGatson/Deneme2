using Application.UnitOfWork;
using MediatR;

namespace Application.Features.Customer.Request.GetAllById
{
    public class GetAllByIdCustomerRequestHandler : IRequestHandler<GetAllByIdCustomerRequest, List<Domain.Entities.Customer>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllByIdCustomerRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<List<Domain.Entities.Customer>> Handle(GetAllByIdCustomerRequest request, CancellationToken cancellationToken)
        {
            var result = _unitOfWork.CustomerRepository.GetAllByIdAsync(request.Id);
            return result;
        }
    }
}
