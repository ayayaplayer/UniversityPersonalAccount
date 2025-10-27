using UniversityPersonalAccount.Models.DTOs.HalfYear;
using UniversityPersonalAccount.Models.Entities;


namespace UniversityPersonalAccount.Services.Interfaces
{
    public interface IHalfYearService
    {
        IEnumerable<HalfYear> GetAll();
        HalfYear? GetById(int id);
        HalfYear Create(HalfYearCreateDto dto);
        void Update(HalfYearUpdateDto dto);
        void Delete(int id);
    }
}