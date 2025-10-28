using System.Collections.Generic;
using UniversityPersonalAccount.Models.DTOs;

namespace UniversityPersonalAccount.Services.Interfaces
{
    public interface IFacultyService
    {
        IEnumerable<FacultyDto> GetAll();
        FacultyDto? GetById(int id);
        FacultyDto Create(FacultyDto dto);
        FacultyDto? Update(int id, FacultyDto dto);
        bool Delete(int id);
    }
}