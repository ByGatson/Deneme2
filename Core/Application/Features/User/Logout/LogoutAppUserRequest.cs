using MediatR;

namespace Application.Features.User.Logout
{
    public sealed record LogoutAppUserRequest : IRequest<LogoutAppUserResponse>
    {
    }
}
