using Application.Interfaces.Redis;
using Application.UnitOfWork;
using MediatR;

namespace Application.Features.Category.Requests.GetAll
{
    public class GetAllCategoriesRequestHandler : IRequestHandler<GetAllCategoriesRequest, List<Domain.Entities.Category>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _redis;

        public GetAllCategoriesRequestHandler(IUnitOfWork unitOfWork, ICacheService redis)
        {
            _unitOfWork = unitOfWork;
            _redis = redis;
        }

        public async Task<List<Domain.Entities.Category>> Handle(GetAllCategoriesRequest request, CancellationToken cancellationToken)
        {
            var categories = await _unitOfWork.CategoryRepository.GetAll();
            var companyId = await _redis.GetAsync("companyId");
            return categories;
            throw new NotImplementedException();
        }
    }
}
