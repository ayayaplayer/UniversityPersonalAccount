using AutoMapper;
using UniversityPersonalAccount.Models.Entities;
using UniversityPersonalAccount.Models.DTOs;


namespace UniversityPersonalAccount.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           
            CreateMap<Course, CourseGetAllDto>();
            CreateMap<Course, CourseGetByIdDto>();
            CreateMap<CourseCreateDto, Course>();
            CreateMap<CourseUpdateDto, Course>();
            CreateMap<Course, CourseBasicDto>();

            
            CreateMap<Faculty, FacultyGetAllDto>();
            CreateMap<Faculty, FacultyGetByIdDto>();
                
            CreateMap<FacultyCreateDto, Faculty>();
            CreateMap<FacultyUpdateDto, Faculty>();
            CreateMap<Faculty, FacultyBasicDto>();


            CreateMap<Group, GroupGetAllDto>();


            CreateMap<Group, GroupGetByIdDto>();
               
            CreateMap<GroupCreateDto, Group>();
            CreateMap<GroupUpdateDto, Group>();
            CreateMap<Group, GroupBasicDto>();

        
            CreateMap<Student, StudentGetAllDto>();
            CreateMap<Student, StudentGetByIdDto>();
            CreateMap<StudentCreateDto, Student>();
            CreateMap<StudentUpdateDto, Student>();
            CreateMap<Student, StudentBasicDto>();

           
            CreateMap<HalfYear, HalfYearGetAllDto>();
            CreateMap<HalfYear, HalfYearGetByIdDto>();
                
            CreateMap<HalfYearCreateDto, HalfYear>();
            CreateMap<HalfYearUpdateDto, HalfYear>();
            CreateMap<HalfYear, HalfYearBasicDto>();

           
            CreateMap<Session, SessionGetAllDto>();
            CreateMap<Session, SessionGetByIdDto>();              
            CreateMap<SessionCreateDto, Session>();
            CreateMap<SessionUpdateDto, Session>();
            CreateMap<Session, SessionBasicDto>();

           
            CreateMap<Schedule, ScheduleGetAllDto>();
            CreateMap<Schedule, ScheduleGetByIdDto>();             
            CreateMap<ScheduleCreateDto, Schedule>();
            CreateMap<ScheduleUpdateDto, Schedule>();
        }
    }
}