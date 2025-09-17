using Application.UnitOfWork;
using MediatR;

namespace Application.Features.Company.Request.GetAllById
{
    public class GetAllByIdRequestHandler : IRequestHandler<GetAllByIdRequest, List<Domain.Entities.Company>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllByIdRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Domain.Entities.Company>> Handle(GetAllByIdRequest request, CancellationToken cancellationToken)
        {
            var response = await _unitOfWork.CompanyRepository.GetAllByUserIdAsync(request.userId);
            return response;
        }
    }
}
