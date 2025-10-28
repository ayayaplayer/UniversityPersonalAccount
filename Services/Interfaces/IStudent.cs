using System.Collections.Generic;
using UniversityPersonalAccount.Models.DTOs;

namespace UniversityPersonalAccount.Services.Interfaces
{
    public interface IStudentService
    {
        IEnumerable<StudentDto> GetAll();
        StudentDto? GetById(int id);
        StudentDto Create(StudentDto dto);
        StudentDto? Update(int id, StudentDto dto);
        bool Delete(int id);
    }
}