using Application.Features.Category.Commands.Create;
using Application.Features.Category.Commands.Update;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings.CategoryMap
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<UpdateCategoryCommand, Category>();
        }

    }
}
