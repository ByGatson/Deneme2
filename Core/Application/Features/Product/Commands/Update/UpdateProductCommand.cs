using MediatR;

namespace Application.Features.Product.Commands.Update
{
    public sealed record UpdateProductCommand(string Id, string FullName, string Price) : IRequest<bool>
    {
    }
}
