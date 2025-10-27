using UniversityPersonalAccount.Models.DTOs.Session;
using UniversityPersonalAccount.Models.Entities;

namespace UniversityPersonalAccount.Services.Interfaces
{
    public interface ISessionService
    {
        IEnumerable<Session> GetAll();
        Session? GetById(int id);
        Session Create(SessionCreateDto dto);
        void Update(SessionUpdateDto dto);
        void Delete(int id);
    }
}