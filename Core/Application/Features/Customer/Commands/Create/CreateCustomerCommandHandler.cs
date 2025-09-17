using Application.Interfaces.Redis;
using Application.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Application.Features.Customer.Commands.Create
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _redis;
        public CreateCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ICacheService redis)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _redis = redis;
        }
        public async Task<bool> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<Domain.Entities.Customer>(request);
            await _unitOfWork.CustomerRepository.AddAsync(customer);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
