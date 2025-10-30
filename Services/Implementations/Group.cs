using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UniversityPersonalAccount.Data;
using UniversityPersonalAccount.Models.DTOs;
using UniversityPersonalAccount.Models.Entities;
using UniversityPersonalAccount.Services.Interfaces;

namespace UniversityPersonalAccount.Services
{
    public class GroupService : BaseCrudService<Group, GroupDto>, IGroupService
    {
        public GroupService(PersonalAccountDbContext context, IMapper mapper, ILogger<GroupService> logger)
            : base(context, mapper, logger)
        {
        }

        public override IEnumerable<GroupDto> GetAll()
        {
            var groups = _context.Groups.Include(g => g.Students).ToList();
            return _mapper.Map<IEnumerable<GroupDto>>(groups);
        }

        public override GroupDto? GetById(int id)
        {
            var group = _context.Groups
                .Include(g => g.Students)
                .FirstOrDefault(g => g.Id == id);
            return _mapper.Map<GroupDto?>(group);
        }
    }
}
