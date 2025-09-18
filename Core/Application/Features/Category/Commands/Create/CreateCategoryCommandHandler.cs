using Application.Interfaces.Redis;
using Application.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Commands.Create
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _redis;
        private readonly IMapper _mapper;
        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, ICacheService redis, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _redis = redis;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Domain.Entities.Category>(request);
            var companyId = await _redis.GetAsync("companyId");
            category.CompanyId = companyId;
            await _unitOfWork.CategoryRepository.AddAsync(category);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
