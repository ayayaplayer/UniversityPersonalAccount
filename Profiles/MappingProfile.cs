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
            .ForMember(d => d.Groups, opt => opt.MapFrom(s => s.Groups));

        CreateMap<Group, GroupDto>()
            .ForMember(d => d.Students, opt => opt.MapFrom(s => s.Students))
            .ForMember(d => d.FacultyId, opt => opt.MapFrom(s => s.FacultyId))
            .ForMember(d => d.CourseId, opt => opt.MapFrom(s => s.CourseId));

        
        CreateMap<Group, GroupShortDto>();
        CreateMap<Student, StudentShortDto>()
            .ForMember(d => d.FullName, opt => opt.MapFrom(s => $"{s.Name} {s.Surname}".Trim()));
        CreateMap<Session, SessionShortDto>();

        
        CreateMap<Student, StudentDto>().ReverseMap();

        
        CreateMap<Course, CourseDto>()
            .ForMember(d => d.CourseName, opt => opt.MapFrom(s => s.CourseName.ToString()))
            .ForMember(d => d.Groups, opt => opt.MapFrom(s => s.Groups))
            .ForMember(d => d.Students, opt => opt.MapFrom(s => s.Students));

        
        CreateMap<HalfYear, HalfYearDto>()
            .ForMember(d => d.Sessions, opt => opt.MapFrom(s => s.Sessions));

        
        CreateMap<Session, SessionDto>()
            .ForMember(d => d.ClassNumber, opt => opt.MapFrom(s => s.ClassNumber.ToString()));

        
        CreateMap<Schedule, ScheduleDto>()
            .ForMember(d => d.Groups, opt => opt.MapFrom(s => s.Groups))
            .ForMember(d => d.Sessions, opt => opt.MapFrom(s => s.Sessions));
            
        }
    }
}