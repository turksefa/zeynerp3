using AutoMapper;
using zeynerp.Application.DTOs.Company;
using zeynerp.Core.Domain.Entities;

namespace zeynerp.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>().ReverseMap();
        }
    }
}