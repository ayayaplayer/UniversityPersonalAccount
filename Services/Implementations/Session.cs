using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using UniversityPersonalAccount.Models.DTOs;
using UniversityPersonalAccount.Models.Entities;
using UniversityPersonalAccount.Data;
using UniversityPersonalAccount.Services.Interfaces;

namespace UniversityPersonalAccount.Services
{
    public class SessionService : ISessionService
    {
        private readonly PersonalAccountDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<SessionService> _logger;

        public SessionService(PersonalAccountDbContext context, IMapper mapper, ILogger<SessionService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public IEnumerable<SessionDto> GetAll()
        {
            _logger.LogInformation("Получение всех сессий");
            var sessions = _context.Sessions.ToList();
            return _mapper.Map<IEnumerable<SessionDto>>(sessions);
        }

        public SessionDto? GetById(int id)
        {
            _logger.LogInformation("Получение сессии Id={Id}", id);
            var session = _context.Sessions.FirstOrDefault(s => s.Id == id);
            return session == null ? null : _mapper.Map<SessionDto>(session);
        }

        public SessionDto Create(SessionDto dto)
        {
            _logger.LogInformation("Создание новой сессии");
            var entity = _mapper.Map<Session>(dto);
            _context.Sessions.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<SessionDto>(entity);
        }

        public SessionDto? Update(int id, SessionDto dto)
        {
            _logger.LogInformation("Обновление сессии Id={Id}", id);
            var existing = _context.Sessions.FirstOrDefault(s => s.Id == id);
            if (existing == null) return null;

            existing.ClassNumber = Enum.Parse<ClassNumber>(dto.ClassNumber);
            existing.StartTime = dto.StartTime;
            existing.EndTime = dto.EndTime;
            existing.HalfYearId = dto.HalfYearId;

            _context.SaveChanges();
            return _mapper.Map<SessionDto>(existing);
        }

        public bool Delete(int id)
        {
            _logger.LogInformation("Удаление сессии Id={Id}", id);
            var entity = _context.Sessions.FirstOrDefault(s => s.Id == id);
            if (entity == null) return false;

            _context.Sessions.Remove(entity);
            _context.SaveChanges();
            return true;
        }
    }
}
