using System.Collections.Generic;
using UniversityPersonalAccount.Models.DTOs;

namespace UniversityPersonalAccount.Services.Interfaces
{
    public interface IHalfYearService
    {
        IEnumerable<HalfYearDto> GetAll();
        HalfYearDto? GetById(int id);
        HalfYearDto Create(HalfYearDto dto);
        HalfYearDto? Update(int id, HalfYearDto dto);
        bool Delete(int id);
    }
}