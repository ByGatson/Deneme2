using Application.DTOs;

namespace Application.Interfaces.JwtToken
{
    public interface ITokenService
    {
        public Token CreateAccessToken();
    }
}
