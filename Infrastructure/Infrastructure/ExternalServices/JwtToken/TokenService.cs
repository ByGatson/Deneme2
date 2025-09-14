using Application.DTOs;
using Application.Interfaces.JwtToken;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Infrastructure.ExternalServices.JwtToken
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _builder;

        public TokenService(IConfiguration builder)
        {
            _builder = builder;
        }

        public Token CreateAccessToken()
        {
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_builder["Token:SecurityKey"] ?? ""));
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);
            Token token = new()
            {
                Expiration = DateTime.UtcNow.AddMinutes(5)
            };

            JwtSecurityToken jwtSecurityToken = new(
                audience: _builder["Token:Audience"],
                issuer: _builder["Token:Issuer"],
                expires: token.Expiration,
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials
                );
            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(jwtSecurityToken);
            return token;
        }
    }
}
