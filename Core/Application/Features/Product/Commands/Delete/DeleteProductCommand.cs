using MediatR;

namespace Application.Features.Product.Commands.Delete
{
    public sealed record DeleteProductCommand(string Id) : IRequest<bool>
    {
    }
}
