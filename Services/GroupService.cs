using UniversityPersonalAccount.Data;
using UniversityPersonalAccount.Models.Entities;
using UniversityPersonalAccount.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UniversityPersonalAccount.Models.DTOs.Group;

namespace UniversityPersonalAccount.Services;

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

    public IEnumerable<Group> GetAll()
    {
        try
        {
            return _context.Groups
                .ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при получении всех групп");
            throw;
        }
    }

    public Group? GetById(int id)
    {
        try
        {
            return _context.Groups
                .FirstOrDefault(g => g.Id == id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Ошибка при получении группы с ID {id}");
            throw;
        }
    }

    public Group Create(GroupCreateDto dto)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(dto.GroupName))
                throw new ArgumentException("Название группы не может быть пустым");
            var group = _mapper.Map<Group>(dto);
            _context.Groups.Add(group);
            _context.SaveChanges();

            _logger.LogInformation($"Группа '{dto.GroupName}' успешно создана");
            return group;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при создании группы");
            throw;
        }
    }

    public void Update(GroupUpdateDto dto)
    {
        try
        {
            var group = _context.Groups
                .Find(dto.Id);
            if (group == null)
                throw new KeyNotFoundException($"Группа с ID {dto.Id} не найдена");

          

            _mapper.Map(dto, group);
            _context.Groups.Update(group);
            _context.SaveChanges();

            _logger.LogInformation($"Группа с ID {dto.Id} успешно обновлена");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Ошибка при обновлении группы {dto.Id}");
            throw;
        }
    }

    public void Delete(int id)
    {
        try
        {
            var group = _context.Groups.Find(id);
            if (group == null)
                throw new KeyNotFoundException($"Группа с ID {id} не найдена");

            _context.Groups.Remove(group);
            _context.SaveChanges();

            _logger.LogInformation($"Группа с ID {id} успешно удалена");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Ошибка при удалении группы {id}");
            throw;
        }
    }
}
