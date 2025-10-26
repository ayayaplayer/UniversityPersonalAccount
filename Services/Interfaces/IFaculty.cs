using UniversityPersonalAccount.Models.DTOs;
using UniversityPersonalAccount.Models.Entities;

 namespace UniversityPersonalAccount.Services.Interfaces
 {
    public interface IFacultyService
    {
        IEnumerable<Faculty> GetAll();
        Faculty? GetById(int id);
        Faculty Create(FacultyCreateDto dto);
        void Update(FacultyUpdateDto dto);
        void Delete(int id);
    }

 }