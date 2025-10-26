using UniversityPersonalAccount.Models.DTOs;
using UniversityPersonalAccount.Models.Entities;

namespace UniversityPersonalAccount.Services.Interfaces
{
     public interface IScheduleService
    {
        IEnumerable<Schedule> GetAll();
        Schedule? GetById(int id);
        Schedule Create(ScheduleCreateDto dto);
        void Update(ScheduleUpdateDto dto);
        void Delete(int id);
    }
}