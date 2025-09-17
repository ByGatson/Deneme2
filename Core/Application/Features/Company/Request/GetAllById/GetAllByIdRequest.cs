using MediatR;

namespace Application.Features.Company.Request.GetAllById
{
    public sealed record GetAllByIdRequest(string userId) : IRequest<List<Domain.Entities.Company>>
    {
    }
}
