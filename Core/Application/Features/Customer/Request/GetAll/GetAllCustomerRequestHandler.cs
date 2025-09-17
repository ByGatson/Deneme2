using Application.UnitOfWork;
using MediatR;

namespace Application.Features.Customer.Request.GetAll
{
    public class GetAllCustomerRequestHandler : IRequestHandler<GetAllCustomerRequest, List<Domain.Entities.Customer>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCustomerRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Domain.Entities.Customer>> Handle(GetAllCustomerRequest request, CancellationToken cancellationToken)
            => await _unitOfWork.CustomerRepository.GetAll();

    }
}
