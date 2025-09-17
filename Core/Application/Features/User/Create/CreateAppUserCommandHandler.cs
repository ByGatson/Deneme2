using Application.Exceptions;
using AutoMapper;
using Domain.Entities.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.User.Create
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand, CreateAppUserResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public CreateAppUserCommandHandler(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<CreateAppUserResponse> Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            var appUser = _mapper.Map<AppUser>(request);
            var response = await _userManager.CreateAsync(appUser);
            if (response.Succeeded)
            {
                return new CreateAppUserResponse(appUser.Id);
            }
            throw new CreateOperationIsFailed();
        }
    }
}
