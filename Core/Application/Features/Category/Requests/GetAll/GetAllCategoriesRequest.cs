using MediatR;

namespace Application.Features.Category.Requests.GetAll
{
    public sealed record GetAllCategoriesRequest : IRequest<List<Domain.Entities.Category>>
    {
    }
}
