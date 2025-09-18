using Application.UnitOfWork;
using MediatR;

namespace Application.Features.Category.Commands.Delete
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = await _unitOfWork.CategoryRepository.RemoveAsync(request.Id);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
