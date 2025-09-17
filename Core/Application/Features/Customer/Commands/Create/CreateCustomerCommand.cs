using MediatR;

namespace Application.Features.Customer.Commands.Create
{
    public sealed record CreateCustomerCommand(string FullName, string Address) : IRequest<bool>
    {
        public string Id { get; } = Guid.NewGuid().ToString();
    }
}
