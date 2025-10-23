using AutoMapper;
using UniversityPersonalAccount.Models.Entities;

namespace UniversityPersonalAccount.Models.DTOs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Student Mappings
            CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.Group, opt => opt.MapFrom(src => src.group));
            CreateMap<StudentDto, Student>()
                .ForMember(dest => dest.group, opt => opt.MapFrom(src => src.Group));
            CreateMap<StudentCreateDto, Student>();
            CreateMap<StudentUpdateDto, Student>();

            // Session Mappings
            CreateMap<Session, SessionDto>();
            CreateMap<SessionDto, Session>();
            CreateMap<SessionCreateDto, Session>();
            CreateMap<SessionUpdateDto, Session>();

            // Schedule Mappings
            CreateMap<Schedule, ScheduleDto>();
            CreateMap<ScheduleDto, Schedule>();
            CreateMap<ScheduleCreateDto, Schedule>();
            CreateMap<ScheduleUpdateDto, Schedule>();

            // HalfYear Mappings
            CreateMap<HalfYear, HalfYearDto>();
            CreateMap<HalfYearDto, HalfYear>();
            CreateMap<HalfYearCreateDto, HalfYear>();
            CreateMap<HalfYearUpdateDto, HalfYear>();

            // Group Mappings
            CreateMap<Group, GroupDto>();
            CreateMap<GroupDto, Group>();
            CreateMap<GroupCreateDto, Group>();
            CreateMap<GroupUpdateDto, Group>();

            // Faculty Mappings
            CreateMap<Faculty, FacultyDto>();
            CreateMap<FacultyDto, Faculty>();
            CreateMap<FacultyCreateDto, Faculty>();
            CreateMap<FacultyUpdateDto, Faculty>();

            // Course Mappings
            CreateMap<Course, CourseDto>();
            CreateMap<CourseDto, Course>();
            CreateMap<CourseCreateDto, Course>();
            CreateMap<CourseUpdateDto, Course>();
        }
    }
}