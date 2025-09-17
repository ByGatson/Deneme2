using MediatR;

namespace Application.Features.Customer.Commands.Create
{
    public record DeleteCustomerCommand(string Id) : IRequest<bool>
    {
    }
}
