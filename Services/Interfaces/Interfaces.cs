using System.Collections.Generic;
using UniversityPersonalAccount.Models.DTOs;

namespace UniversityPersonalAccount.Services.Interfaces
{
    public interface ICrudService<TDto>
    {
        IEnumerable<TDto> GetAll();
        TDto? GetById(int id);
        TDto Create(TDto dto);
        TDto? Update(int id, TDto dto);
        bool Delete(int id);
    }

    public interface IFacultyService : ICrudService<FacultyDto> { }
    public interface ICourseService : ICrudService<CourseDto> { }
    public interface IGroupService : ICrudService<GroupDto> { }
    public interface IHalfYearService : ICrudService<HalfYearDto> { }
    public interface IScheduleService : ICrudService<ScheduleDto> { }
    public interface ISessionService : ICrudService<SessionDto> { }
    public interface IStudentService : ICrudService<StudentDto> { }
}
