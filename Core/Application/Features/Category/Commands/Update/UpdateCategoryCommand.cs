using MediatR;

namespace Application.Features.Category.Commands.Update
{
    public sealed record UpdateCategoryCommand(string Id, string CategoryName) : IRequest<bool>
    {
    }
}
