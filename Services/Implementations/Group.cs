using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UniversityPersonalAccount.Data;
using UniversityPersonalAccount.Models.DTOs;
using UniversityPersonalAccount.Models.Entities;
using UniversityPersonalAccount.Services.Interfaces;

namespace UniversityPersonalAccount.Services
{
    public class GroupService : IGroupService
    {
        private readonly PersonalAccountDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GroupService> _logger;

        public GroupService(PersonalAccountDbContext context, IMapper mapper, ILogger<GroupService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public IEnumerable<GroupDto> GetAll()
        {
            _logger.LogInformation("Получение всех групп");
            var groups = _context.Groups.Include(g => g.Students).ToList();
            return _mapper.Map<List<GroupDto>>(groups);
        }

        public GroupDto? GetById(int id)
        {
            _logger.LogInformation("Получение группы Id={Id}", id);
            var group = _context.Groups.Include(g => g.Students).FirstOrDefault(g => g.Id == id);
            return group == null ? null : _mapper.Map<GroupDto>(group);
        }

        public GroupDto Create(GroupDto dto)
        {
            _logger.LogInformation("Создание группы: {Name}", dto.GroupName);
            var entity = _mapper.Map<Group>(dto);
            _context.Groups.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<GroupDto>(entity);
        }

        public GroupDto? Update(int id, GroupDto dto)
        {
            _logger.LogInformation("Обновление группы Id={Id}", id);
            var existing = _context.Groups.Include(g => g.Students).FirstOrDefault(g => g.Id == id);
            if (existing == null) return null;

            existing.GroupName = dto.GroupName;
            existing.FacultyId = dto.FacultyId;
            existing.CourseId = dto.CourseId;
            _context.SaveChanges();

            return _mapper.Map<GroupDto>(existing);
        }

        public bool Delete(int id)
        {
            _logger.LogInformation("Удаление группы Id={Id}", id);
            var entity = _context.Groups.FirstOrDefault(g => g.Id == id);
            if (entity == null) return false;

            _context.Groups.Remove(entity);
            _context.SaveChanges();
            return true;
        }
    }
}
