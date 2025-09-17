using Application.Features.Customer.Commands.Create;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings.CustomerMap
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CreateCustomerCommand, Customer>();
            CreateMap<UpdateCustomerCommand, Customer>();
        }
    }
}
