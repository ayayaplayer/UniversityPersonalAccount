using System.Collections.Generic;
using UniversityPersonalAccount.Models.DTOs;

namespace UniversityPersonalAccount.Services.Interfaces
{
    public interface IScheduleService
    {
        IEnumerable<ScheduleDto> GetAll();
        ScheduleDto? GetById(int id);
        ScheduleDto Create(ScheduleDto dto);
        ScheduleDto? Update(int id, ScheduleDto dto);
        bool Delete(int id);
    }
}