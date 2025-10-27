using UniversityPersonalAccount.Data;
using UniversityPersonalAccount.Models.Entities;
using UniversityPersonalAccount.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UniversityPersonalAccount.Models.DTOs.Schedule;

namespace UniversityPersonalAccount.Services;


public class ScheduleService : IScheduleService
{
    private readonly PersonalAccountDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger<ScheduleService> _logger;

    public ScheduleService(PersonalAccountDbContext context, IMapper mapper, ILogger<ScheduleService> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    public IEnumerable<Schedule> GetAll()
    {
        try
        {
            return _context.Schedules.ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при получении всех расписаний");
            throw;
        }
    }

    public Schedule? GetById(int id)
    {
        try
        {
            return _context.Schedules               
                .FirstOrDefault(s => s.Id == id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Ошибка при получении расписания с ID {id}");
            throw;
        }
    }

    public Schedule Create(ScheduleCreateDto dto)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(dto.SubjectName))
                throw new ArgumentException("Название предмета не может быть пустым");

            var schedule = _mapper.Map<Schedule>(dto);
            _context.Schedules.Add(schedule);
            _context.SaveChanges();

            _logger.LogInformation($"Расписание '{dto.SubjectName}' успешно создано");
            return schedule;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при создании расписания");
            throw;
        }
    }

    public void Update(ScheduleUpdateDto dto)
    {
        try
        {
            var schedule = _context.Schedules.Find(dto.Id);
            if (schedule == null)
                throw new KeyNotFoundException($"Расписание с ID {dto.Id} не найдено");

            _mapper.Map(dto, schedule);
            _context.Schedules.Update(schedule);
            _context.SaveChanges();

            _logger.LogInformation($"Расписание с ID {dto.Id} успешно обновлено");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Ошибка при обновлении расписания {dto.Id}");
            throw;
        }
    }

    public void Delete(int id)
    {
        try
        {
            var schedule = _context.Schedules.Find(id);
            if (schedule == null)
                throw new KeyNotFoundException($"Расписание с ID {id} не найдено");

            _context.Schedules.Remove(schedule);
            _context.SaveChanges();

            _logger.LogInformation($"Расписание с ID {id} успешно удалено");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Ошибка при удалении расписания {id}");
            throw;
        }
    }
}
