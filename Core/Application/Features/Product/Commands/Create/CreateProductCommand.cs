using MediatR;

namespace Application.Features.Product.Commands.Create
{
    public sealed record CreateProductCommand(string FullName, string Price) : IRequest<bool>
    {
        public string Id { get; } = Guid.NewGuid().ToString();
    }
}
