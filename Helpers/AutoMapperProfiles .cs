
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


            CreateMap<StudentRegisterDto, Student>()
                   .ForMember(dest => dest.StudentId, opt => opt.Ignore()) // Ignore mapping the StudentId property
                   .ForMember(dest => dest.Attendances, opt => opt.Ignore()) // Ignore mapping the Attendances navigation property
                   .ForMember(dest => dest.SectionStudents, opt => opt.Ignore()) // Ignore mapping the SectionStudents navigation property
                   .ForMember(dest => dest.User, opt => opt.Ignore()); // Ignore mapping the User navigation property

            ;
            CreateMap<StudentShowDto, Student>();
            CreateMap<Student, StudentShowDto > ();


            CreateMap<Department, DepartmentDto>()
                .ReverseMap();

            CreateMap<College, CollegeDto>()
                .ReverseMap();
        }
    }
}
