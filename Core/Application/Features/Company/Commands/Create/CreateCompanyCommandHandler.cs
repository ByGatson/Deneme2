using Application.Interfaces.Redis;
using Application.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Application.Features.Company.Commands.Create
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _redis;
        public CreateCompanyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ICacheService redis)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _redis = redis;
        }

        public async Task<bool> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = _mapper.Map<Domain.Entities.Company>(request);
            var userId = await _redis.GetAsync("userId");
            if (userId is not null)
                company.UserId = userId;

            await _unitOfWork.CompanyRepository.AddAsync(company);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _redis.SetAsync("companyId", company.Id);
            return result > 0;
        }
    }
}
