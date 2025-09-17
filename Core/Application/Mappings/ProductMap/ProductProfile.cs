using Application.Features.Product.Commands.Create;
using Application.Features.Product.Commands.Update;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings.ProductMap
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();
        }
    }
}
