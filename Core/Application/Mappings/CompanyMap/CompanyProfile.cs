using Application.Features.Company.Commands.Create;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings.CompanyMap
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<CreateCompanyCommand, Company>();
            CreateMap<UpdateCompanyCommand, Company>();
        }
    }
}
