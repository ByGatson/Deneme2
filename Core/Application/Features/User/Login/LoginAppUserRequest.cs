using MediatR;

namespace Application.Features.User.Login
{
    public sealed record LoginAppUserRequest(string FullNameorEmail, string password) : IRequest<LoginAppUserResponse>
    {
    }
}
