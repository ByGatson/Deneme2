using Application.Interfaces.Redis;
using Application.UnitOfWork;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Features.Company.Request.GetAll
{
    public class GetAllCompanyRequestHandler : IRequestHandler<GetAllCompanyRequest, List<Domain.Entities.Company>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _memoryCache;

        public GetAllCompanyRequestHandler(IUnitOfWork unitOfWork, ICacheService redis, IMemoryCache memoryCache)
        {
            _unitOfWork = unitOfWork;
            _memoryCache = memoryCache;
        }

        public async Task<List<Domain.Entities.Company>> Handle(GetAllCompanyRequest request, CancellationToken cancellationToken)
        {
            var cacheResult = _memoryCache.Get("companyList");
            if (cacheResult is null)
            {
                cacheResult = await _unitOfWork.CompanyRepository.GetAll();
                _memoryCache.Set("companyList", cacheResult);
            }
            return (List<Domain.Entities.Company>)cacheResult;
        }
    }
}
