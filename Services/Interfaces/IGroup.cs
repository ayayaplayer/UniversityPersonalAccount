using System.Collections.Generic;
using UniversityPersonalAccount.Models.DTOs;

namespace UniversityPersonalAccount.Services.Interfaces
{
    public interface IGroupService
    {
        IEnumerable<GroupDto> GetAll();
        GroupDto? GetById(int id);
        GroupDto Create(GroupDto dto);
        GroupDto? Update(int id, GroupDto dto);
        bool Delete(int id);
    }
}