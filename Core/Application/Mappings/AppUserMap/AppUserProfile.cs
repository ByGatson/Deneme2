using Application.Features.User.Create;
using AutoMapper;
using Domain.Entities.Auth;

namespace Application.Mappings.AppUserMap
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            CreateMap<CreateAppUserCommand, AppUser>();
        }
    }
}
