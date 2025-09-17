using MediatR;

namespace Application.Features.Customer.Request.GetAll
{
    public sealed record GetAllCustomerRequest : IRequest<List<Domain.Entities.Customer>>
    {
    }
}
