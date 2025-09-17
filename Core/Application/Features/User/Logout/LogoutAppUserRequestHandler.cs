using Domain.Entities.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.User.Logout
{
    public class LogoutAppUserRequestHandler : IRequestHandler<LogoutAppUserRequest, LogoutAppUserResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LogoutAppUserRequestHandler(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<LogoutAppUserResponse> Handle(LogoutAppUserRequest request, CancellationToken cancellationToken)
        {
            await _signInManager.SignOutAsync();
            return new LogoutAppUserResponse(true);
        }
    }
}
