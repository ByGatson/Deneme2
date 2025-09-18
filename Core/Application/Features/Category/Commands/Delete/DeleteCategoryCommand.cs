using MediatR;

namespace Application.Features.Category.Commands.Delete
{
    public sealed record DeleteCategoryCommand(string Id) : IRequest<bool>
    {
    }
}
