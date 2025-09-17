using Application.Exceptions;
using Application.Interfaces.JwtToken;
using Application.Interfaces.Redis;
using Domain.Entities.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.User.Login
{
    public class LoginAppUserRequestHandler : IRequestHandler<LoginAppUserRequest, LoginAppUserResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly ICacheService _redis;
        public LoginAppUserRequestHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService, ICacheService redis)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _redis = redis;
        }

        public async Task<LoginAppUserResponse> Handle(LoginAppUserRequest request, CancellationToken cancellationToken)
        {

            var appUser = await _userManager.FindByNameAsync(request.FullNameorEmail);
            if (appUser is null)
            {
                appUser = await _userManager.FindByEmailAsync(request.FullNameorEmail);
                if (appUser is null) throw new UserNotFoundException("Kullanıcı bulunamadı");
            }
            var response = await _signInManager.CheckPasswordSignInAsync(appUser, request.password, false);
            if (!response.Succeeded)
            {
                var token = _tokenService.CreateAccessToken();
                await _redis.SetAsync("userId", appUser.Id);
                return new LoginAppUserResponse(appUser.Id, token);
            }
            throw new UserNotFoundException("Login işlemi başarısız oldu");

        }
    }
}
