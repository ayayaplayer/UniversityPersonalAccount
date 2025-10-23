using AutoMapper;
using UniversityPersonalAccount.Models.Entities;

namespace UniversityPersonalAccount.Models.DTOs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           
            CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.Group, opt => opt.MapFrom(src => src.group));
            CreateMap<StudentDto, Student>()
                .ForMember(dest => dest.group, opt => opt.MapFrom(src => src.Group));
            CreateMap<StudentCreateDto, Student>();
            CreateMap<StudentUpdateDto, Student>();

            
            CreateMap<Session, SessionDto>();
            CreateMap<SessionDto, Session>();
            CreateMap<SessionCreateDto, Session>();
            CreateMap<SessionUpdateDto, Session>();

            
            CreateMap<Schedule, ScheduleDto>();
            CreateMap<ScheduleDto, Schedule>();
            CreateMap<ScheduleCreateDto, Schedule>();
            CreateMap<ScheduleUpdateDto, Schedule>();

            
            CreateMap<HalfYear, HalfYearDto>();
            CreateMap<HalfYearDto, HalfYear>();
            CreateMap<HalfYearCreateDto, HalfYear>();
            CreateMap<HalfYearUpdateDto, HalfYear>();

          
            CreateMap<Group, GroupDto>();
            CreateMap<GroupDto, Group>();
            CreateMap<GroupCreateDto, Group>();
            CreateMap<GroupUpdateDto, Group>();

          
            CreateMap<Faculty, FacultyDto>();
            CreateMap<FacultyDto, Faculty>();
            CreateMap<FacultyCreateDto, Faculty>();
            CreateMap<FacultyUpdateDto, Faculty>();

           
            CreateMap<Course, CourseDto>();
            CreateMap<CourseDto, Course>();
            CreateMap<CourseCreateDto, Course>();
            CreateMap<CourseUpdateDto, Course>();
        }
    }
}
