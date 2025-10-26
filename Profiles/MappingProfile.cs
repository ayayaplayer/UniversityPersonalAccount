using AutoMapper;
using UniversityPersonalAccount.Models.Entities;
using UniversityPersonalAccount.Models.DTOs;


namespace UniversityPersonalAccount.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // ============ COURSE MAPPINGS ============
            CreateMap<Course, CourseGetAllDto>();
            CreateMap<Course, CourseGetByIdDto>()
                .ForMember(dest => dest.Groups, opt => opt.MapFrom(src => src.Groups))
                .ForMember(dest => dest.StudentCount, opt => opt.MapFrom(src => src.Students.Count));
            CreateMap<CourseCreateDto, Course>();
            CreateMap<CourseUpdateDto, Course>();
            CreateMap<Course, CourseBasicDto>();

            // ============ FACULTY MAPPINGS ============
            CreateMap<Faculty, FacultyGetAllDto>();
            CreateMap<Faculty, FacultyGetByIdDto>()
                .ForMember(dest => dest.Groups, opt => opt.MapFrom(src => src.Groups));
            CreateMap<FacultyCreateDto, Faculty>();
            CreateMap<FacultyUpdateDto, Faculty>();
            CreateMap<Faculty, FacultyBasicDto>();

            // ============ GROUP MAPPINGS ============
            CreateMap<Group, GroupGetAllDto>()
                .ForMember(dest => dest.Faculty, opt => opt.MapFrom(src => src.Faculty));
            CreateMap<Group, GroupGetByIdDto>()
                .ForMember(dest => dest.Faculty, opt => opt.MapFrom(src => src.Faculty))
                .ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.Students))
                .ForMember(dest => dest.Courses, opt => opt.MapFrom(src => src.Courses));
            CreateMap<GroupCreateDto, Group>();
            CreateMap<GroupUpdateDto, Group>();
            CreateMap<Group, GroupBasicDto>();

            // ============ STUDENT MAPPINGS ============
            CreateMap<Student, StudentGetAllDto>();
            CreateMap<Student, StudentGetByIdDto>()
                .ForMember(dest => dest.Group, opt => opt.MapFrom(src => src.group))
                .ForMember(dest => dest.Courses, opt => opt.MapFrom(src => src.Courses));
            CreateMap<StudentCreateDto, Student>();
            CreateMap<StudentUpdateDto, Student>();
            CreateMap<Student, StudentBasicDto>();

            // ============ HALFYEAR MAPPINGS ============
            CreateMap<HalfYear, HalfYearGetAllDto>();
            CreateMap<HalfYear, HalfYearGetByIdDto>()
                .ForMember(dest => dest.Sessions, opt => opt.MapFrom(src => src.Sessions));
            CreateMap<HalfYearCreateDto, HalfYear>();
            CreateMap<HalfYearUpdateDto, HalfYear>();
            CreateMap<HalfYear, HalfYearBasicDto>();

            // ============ SESSION MAPPINGS ============
            CreateMap<Session, SessionGetAllDto>();
            CreateMap<Session, SessionGetByIdDto>()
                .ForMember(dest => dest.HalfYear, opt => opt.MapFrom(src => src.HalfYear));
            CreateMap<SessionCreateDto, Session>();
            CreateMap<SessionUpdateDto, Session>();
            CreateMap<Session, SessionBasicDto>();

            // ============ SCHEDULE MAPPINGS ============
            CreateMap<Schedule, ScheduleGetAllDto>();
            CreateMap<Schedule, ScheduleGetByIdDto>()
                .ForMember(dest => dest.Groups, opt => opt.MapFrom(src => src.Groups))
                .ForMember(dest => dest.Sessions, opt => opt.MapFrom(src => src.Sessions));
            CreateMap<ScheduleCreateDto, Schedule>();
            CreateMap<ScheduleUpdateDto, Schedule>();
        }
    }
}