using UniversityPersonalAccount.Models.Entities;
using UniversityPersonalAccount.Models.DTOs.Course;



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