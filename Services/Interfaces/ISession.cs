using System.Collections.Generic;
using UniversityPersonalAccount.Models.DTOs;

namespace UniversityPersonalAccount.Services.Interfaces
{
    public interface ISessionService
    {
        IEnumerable<SessionDto> GetAll();
        SessionDto? GetById(int id);
        SessionDto Create(SessionDto dto);
        SessionDto? Update(int id, SessionDto dto);
        bool Delete(int id);
    }
}