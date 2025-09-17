using MediatR;

namespace Application.Features.Company.Commands.Create
{
    public record DeleteCompanyCommand(string Id) : IRequest<bool>
    {
    }
}
