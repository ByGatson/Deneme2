using Application.Interfaces.Redis;
using Domain.Entities.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Features.User.Logout
{
    public class LogoutAppUserRequestHandler : IRequestHandler<LogoutAppUserRequest, LogoutAppUserResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ICacheService _redis;
        private readonly IMemoryCache _memoryCache;

        public LogoutAppUserRequestHandler(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, ICacheService redis)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _redis = redis;
        }

        public async Task<LogoutAppUserResponse> Handle(LogoutAppUserRequest request, CancellationToken cancellationToken)
        {
            await _signInManager.SignOutAsync();

            await _redis.RemoveAsync("userId");
            await _redis.RemoveAsync("companyId");

            var token = await _redis.GetAsync("activeToken");

            if (!string.IsNullOrEmpty(token))
            {

                var tokenBlackList = _memoryCache.Get<List<string>>("tokenBlackList") ?? new List<string>();

                if (!tokenBlackList.Contains(token))
                    tokenBlackList.Add(token);

                _memoryCache.Set("tokenBlackList", tokenBlackList, TimeSpan.FromHours(1));

                await _redis.RemoveAsync("activeToken");
            }

            return new LogoutAppUserResponse(true);
        }
    }
}

