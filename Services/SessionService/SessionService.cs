using UniversityPersonalAccount.Data;
using UniversityPersonalAccount.Models.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UniversityPersonalAccount.Models.DTOs.Session;
using UniversityPersonalAccount.Services.Interfaces;

namespace UniversityPersonalAccount.Services.SessionService;





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

        public IEnumerable<Session> GetAll()
        {
            try
            {
                return _context.Sessions.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при получении всех занятий");
                throw;
            }
        }

        public Session? GetById(int id)
        {
            try
            {
                return _context.Sessions
                    .FirstOrDefault(s => s.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ошибка при получении занятия с ID {id}");
                throw;
            }
        }

        public Session Create(SessionCreateDto dto)
        {
            try
            {
                if (dto.EndTime <= dto.StartTime)
                    throw new ArgumentException("Время окончания должно быть позже времени начала");

                

                var session = _mapper.Map<Session>(dto);
                _context.Sessions.Add(session);
                _context.SaveChanges();

                _logger.LogInformation($"Занятие успешно создано");
                return session;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при создании занятия");
                throw;
            }
        }

        public void Update(SessionUpdateDto dto)
        {
            try
            {
                var session = _context.Sessions.Find(dto.Id);
                if (session == null)
                    throw new KeyNotFoundException($"Занятие с ID {dto.Id} не найдено");

                if (dto.EndTime <= dto.StartTime)
                    throw new ArgumentException("Время окончания должно быть позже времени начала");

               

                _mapper.Map(dto, session);
                _context.Sessions.Update(session);
                _context.SaveChanges();

                _logger.LogInformation($"Занятие с ID {dto.Id} успешно обновлено");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ошибка при обновлении занятия {dto.Id}");
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var session = _context.Sessions.Find(id);
                if (session == null)
                    throw new KeyNotFoundException($"Занятие с ID {id} не найдено");

                _context.Sessions.Remove(session);
                _context.SaveChanges();

                _logger.LogInformation($"Занятие с ID {id} успешно удалено");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ошибка при удалении занятия {id}");
                throw;
            }
        }
    }