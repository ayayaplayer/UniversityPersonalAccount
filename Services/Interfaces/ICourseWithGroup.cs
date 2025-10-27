using UniversityPersonalAccount.Models.DTOs;
using UniversityPersonalAccount.Models.Entities;

namespace UniversityPersonalAccount.Services.Interfaces
{
    public class ICourseWithGroup
    {
        public interface ICourseWithGroupService
        {
            IEnumerable<Course> GetAll();
            Course? GetById(int id);

        }
    }
}
