using MediatR;

namespace Application.Features.Product.Request.GetAll
{
    public sealed record GetAllProductRequest : IRequest<List<Domain.Entities.Product>>
    {
    }
}
