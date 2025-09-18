using Application.Exceptions;
using Application.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Commands.Update
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.CategoryRepository.FindByIdAsync(request.Id);
            if (category is null) throw new EntityIsNotFoundException("Category bulunamadı");

            _mapper.Map(request, category);

            _unitOfWork.CategoryRepository.Update(category);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;

        }
    }
}
