using UniversityPersonalAccount.Models.DTOs.Course;
using UniversityPersonalAccount.Models.Entities;

namespace UniversityPersonalAccount.Services.Interfaces
{

    public interface ICourseService
    {
        IEnumerable<Course> GetAll();
        Course? GetById(int id);
        Course Create(CourseCreateDto dto);
        void Update(CourseUpdateDto dto);
        void Delete(int id);
    }

}


 
