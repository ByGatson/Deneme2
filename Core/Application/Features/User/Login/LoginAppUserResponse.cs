using Application.DTOs;

namespace Application.Features.User.Login
{
    public record LoginAppUserResponse(string Id, Token AccessToken)
    {
    }
}
