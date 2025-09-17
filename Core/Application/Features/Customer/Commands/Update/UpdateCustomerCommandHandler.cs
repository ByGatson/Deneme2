using Application.Exceptions;
using Application.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Application.Features.Customer.Commands.Create
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerRepository.FindByIdAsync(request.Id);
            if (customer is null) throw new EntityIsNotFoundException("Customer bulunamadı");

            var updatedCustomer = _mapper.Map<Domain.Entities.Company>(request);
            _unitOfWork.CompanyRepository.Update(updatedCustomer);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
