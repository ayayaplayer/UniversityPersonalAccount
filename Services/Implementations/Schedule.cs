using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UniversityPersonalAccount.Data;
using UniversityPersonalAccount.Models.DTOs;
using UniversityPersonalAccount.Models.Entities;
using UniversityPersonalAccount.Services.Interfaces;

namespace UniversityPersonalAccount.Services
{
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

        public IEnumerable<ScheduleDto> GetAll()
        {
            _logger.LogInformation("Получение списка расписаний");
            var schedules = _context.Schedules.Include(s => s.Groups).Include(s => s.Sessions).ToList();
            return _mapper.Map<IEnumerable<ScheduleDto>>(schedules);
        }

        public ScheduleDto? GetById(int id)
        {
            _logger.LogInformation("Получение расписания с Id={Id}", id);
            var schedule = _context.Schedules.Include(s => s.Groups).Include(s => s.Sessions).FirstOrDefault(s => s.Id == id);
            if (schedule == null)
            {
                _logger.LogWarning("Расписание не найдено (Id={Id})", id);
                return null;
            }

            return _mapper.Map<ScheduleDto>(schedule);
        }

        public ScheduleDto Create(ScheduleDto dto)
        {
            _logger.LogInformation("Создание нового расписания: {Subject}", dto.SubjectName);
            var entity = _mapper.Map<Schedule>(dto);
            _context.Schedules.Add(entity);
            _context.SaveChanges();
            _logger.LogInformation("Расписание успешно создано (Id={Id})", entity.Id);
            return _mapper.Map<ScheduleDto>(entity);
        }

        public ScheduleDto? Update(int id, ScheduleDto dto)
        {
            _logger.LogInformation("Обновление расписания с Id={Id}", id);
            var existing = _context.Schedules.Include(s => s.Groups).Include(s => s.Sessions).FirstOrDefault(s => s.Id == id);
            if (existing == null)
            {
                _logger.LogWarning("Расписание для обновления не найдено (Id={Id})", id);
                return null;
            }

            existing.SubjectName = dto.SubjectName;
            existing.Classroom = dto.Classroom;
            _context.SaveChanges();
            _logger.LogInformation("Расписание с Id={Id} успешно обновлено", id);
            return _mapper.Map<ScheduleDto>(existing);
        }

        public bool Delete(int id)
        {
            _logger.LogInformation("Удаление расписания с Id={Id}", id);
            var entity = _context.Schedules.FirstOrDefault(s => s.Id == id);
            if (entity == null)
            {
                _logger.LogWarning("Расписание для удаления не найдено (Id={Id})", id);
                return false;
            }

            _context.Schedules.Remove(entity);
            _context.SaveChanges();
            _logger.LogInformation("Расписание с Id={Id} успешно удалено", id);
            return true;
        }
    }
}
