using UniversityPersonalAccount.Models.DTOs.Group;
using UniversityPersonalAccount.Models.Entities;

namespace UniversityPersonalAccount.Services.Interfaces
 {
    public interface IGroupService
    {
        IEnumerable<Group> GetAll();
        Group? GetById(int id);
        Group Create(GroupCreateDto dto);
        void Update(GroupUpdateDto dto);
        void Delete(int id);
    }

 }