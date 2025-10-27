using UniversityPersonalAccount.Models.DTOs.Course;
using UniversityPersonalAccount.Models.Entities;

namespace UniversityPersonalAccount.Services.Interfaces
{
    public interface ICourseWithGroupService
    {
        IEnumerable<Course> GetAll();
        Course? GetById(int id);
       
    }
}
