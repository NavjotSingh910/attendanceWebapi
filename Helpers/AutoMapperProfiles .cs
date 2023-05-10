
using attendaceAppWebApi.DTOs;
using attendaceAppWebApi.Models;
using attendanceAppWebApi.DTOs;
using AutoMapper;

namespace attendaceAppWebApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserLoginDto>();
            CreateMap<UserLoginDto, User>();
            CreateMap<UserRegistrationDto, User>();
            CreateMap<User, UserRegistrationDto>();

            CreateMap<StudentRegisterDto, UserRegistrationDto>()
                    .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                    .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
            CreateMap<StudentShowDto, Student>();
            CreateMap<Student, StudentShowDto > ();

        }
    }
}
