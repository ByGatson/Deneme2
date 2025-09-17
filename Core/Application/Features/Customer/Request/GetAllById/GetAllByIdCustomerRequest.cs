using MediatR;

namespace Application.Features.Customer.Request.GetAllById
{
    public sealed record GetAllByIdCustomerRequest(string Id) : IRequest<List<Domain.Entities.Customer>>
    {
    }
}
