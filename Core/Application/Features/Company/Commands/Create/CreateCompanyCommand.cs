using MediatR;

namespace Application.Features.Company.Commands.Create
{
    public sealed record CreateCompanyCommand(string CompanyName, string CompanyAddress) : IRequest<bool>
    {
        public string Id { get; } = Guid.NewGuid().ToString();
    }
}
