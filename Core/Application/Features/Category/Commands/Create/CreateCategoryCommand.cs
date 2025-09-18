using MediatR;

namespace Application.Features.Category.Commands.Create
{
    public sealed record CreateCategoryCommand(string CategoryName) : IRequest<bool>
    {
    }
}
