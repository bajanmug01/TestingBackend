using TestingBackend.BusinessLayer.Dtos;
using TestingBackend.DataLayer.Entities;
using AutoMapper;

namespace TestingBackend.BusinessLayer.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Test, TestDto>().ReverseMap();
        }
    }
}
