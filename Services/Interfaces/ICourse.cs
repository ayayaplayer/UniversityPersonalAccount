using System.Collections.Generic;
using UniversityPersonalAccount.Models.DTOs;

namespace UniversityPersonalAccount.Services.Interfaces
{
    public interface ICourseService
    {
        IEnumerable<CourseDto> GetAll();
        CourseDto? GetById(int id);
        CourseDto Create(CourseDto dto);
        CourseDto? Update(int id, CourseDto dto);
        bool Delete(int id);
    }
}