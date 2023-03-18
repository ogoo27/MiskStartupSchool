
using AutoMapper;
using MiskStartupSchool.DTO;
using MiskStartupSchool.Entities;
using MiskStartupSchool.Repository;

namespace MiskStartupSchool.Helpers
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<ApplicationForm , ProgramDto>().ReverseMap();

        }

    }
}
