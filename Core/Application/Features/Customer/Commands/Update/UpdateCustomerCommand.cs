using MediatR;

namespace Application.Features.Customer.Commands.Create
{
    public sealed record UpdateCustomerCommand(string Id, string FullName, string Address) : IRequest<bool>
    {
    }
}
