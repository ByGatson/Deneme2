using MediatR;

namespace Application.Features.Company.Commands.Create
{
    public sealed record UpdateCompanyCommand(string Id, string CompanyName, string CompanyAddress) : IRequest<bool>
    {
    }
}
