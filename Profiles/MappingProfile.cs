using AutoMapper;
using UniversityPersonalAccount.Models.DTOs;
using UniversityPersonalAccount.Models.Entities;


namespace UniversityPersonalAccount.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Faculty, FacultyDto>()
                .ForMember(dest => dest.Groups, opt => opt.MapFrom(src => src.Groups))
                .ReverseMap();

                CreateMap<Course, CourseDto>()
                    .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.CourseName.ToString()))
                    .ForMember(dest => dest.DegreeLevel, opt => opt.MapFrom(src => src.DegreeLevel.ToString()))
                    .ForMember(dest => dest.Groups, opt => opt.MapFrom(src => src.Groups))
                    .ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.Students))
                    .ReverseMap()
                    .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src =>
                        Enum.IsDefined(typeof(CourseName), src.CourseName)
                            ? (CourseName)Enum.Parse(typeof(CourseName), src.CourseName)
                            : CourseName.First))
                    .ForMember(dest => dest.DegreeLevel, opt => opt.MapFrom(src =>
                        Enum.IsDefined(typeof(DegreeLevel), src.DegreeLevel)
                            ? (DegreeLevel)Enum.Parse(typeof(DegreeLevel), src.DegreeLevel)
                            : DegreeLevel.First))
                    .ForMember(dest => dest.Groups, opt => opt.Ignore())
                    .ForMember(dest => dest.Students, opt => opt.Ignore());

            CreateMap<Group, GroupDto>()
                .ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.Students))
                .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.CourseId))
                .ForMember(dest => dest.FacultyId, opt => opt.MapFrom(src => src.FacultyId))
                .ReverseMap();

            CreateMap<HalfYear, HalfYearDto>()
                .ForMember(dest => dest.Sessions, opt => opt.MapFrom(src => src.Sessions))
                .ReverseMap();

            CreateMap<Schedule, ScheduleDto>()
                .ForMember(dest => dest.GroupIds, opt => opt.MapFrom(src => src.Groups.Select(g => g.Id)))
                .ForMember(dest => dest.SessionIds, opt => opt.MapFrom(src => src.Sessions.Select(s => s.Id)))
                .ReverseMap()
                .ForMember(dest => dest.Groups, opt => opt.Ignore())
                .ForMember(dest => dest.Sessions, opt => opt.Ignore());

            CreateMap<Session, SessionDto>()
                .ForMember(dest => dest.ClassNumber, opt => opt.MapFrom(src => src.ClassNumber.ToString()))
                .ReverseMap();

            CreateMap<Student, StudentDto>().ReverseMap();
        }
    }
}
