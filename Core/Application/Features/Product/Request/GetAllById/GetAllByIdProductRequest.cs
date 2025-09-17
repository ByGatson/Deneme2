using MediatR;

namespace Application.Features.Product.Request.GetAllById
{
    public sealed record GetAllByIdProductRequest(string Id) : IRequest<List<Domain.Entities.Product>>
    {
    }
}
