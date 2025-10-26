using UniversityPersonalAccount.Models.Entities;
using UniversityPersonalAccount.Models.DTOs;

namespace UniversityPersonalAccount.Services.Interfaces
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAll();
        Student? GetById(int id);
        Student Create(StudentCreateDto dto);
        void Update(StudentUpdateDto dto);
        void Delete(int id);
    }
}