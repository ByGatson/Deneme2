using MediatR;

namespace Application.Features.User.Create
{
    public sealed record CreateAppUserCommand(string FullName, string Email, string UserName, string Password) : IRequest<CreateAppUserResponse>
    {
        public string Id { get; private set; } = Guid.NewGuid().ToString();
    }
}
