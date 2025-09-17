using MediatR;

namespace Application.Features.Company.Request.GetAll
{
    public class GetAllCompanyRequest : IRequest<List<Domain.Entities.Company>>
    {
    }
}
