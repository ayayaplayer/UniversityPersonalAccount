using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UniversityPersonalAccount.Data;
using UniversityPersonalAccount.Models.DTOs;
using UniversityPersonalAccount.Models.Entities;
using UniversityPersonalAccount.Services.Interfaces;

namespace UniversityPersonalAccount.Services
{
    public class HalfYearService  : IHalfYearService
    {
        private readonly PersonalAccountDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<HalfYearService> _logger;

        public HalfYearService(PersonalAccountDbContext context, IMapper mapper, ILogger<HalfYearService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public IEnumerable<HalfYearDto> GetAll()
        {
            _logger.LogInformation("Получение списка полугодий");
            var list = _context.HalfYears.Include(h => h.Sessions).ToList();
            return _mapper.Map<IEnumerable<HalfYearDto>>(list);
        }

        public HalfYearDto? GetById(int id)
        {
            _logger.LogInformation("Получение полугодия с Id={Id}", id);
            var entity = _context.HalfYears.Include(h => h.Sessions).FirstOrDefault(h => h.Id == id);
            if (entity == null)
            {
                _logger.LogWarning("Полугодие не найдено (Id={Id})", id);
                return null;
            }

            return _mapper.Map<HalfYearDto>(entity);
        }

        public HalfYearDto Create(HalfYearDto dto)
        {
            _logger.LogInformation("Создание нового полугодия");
            var entity = _mapper.Map<HalfYear>(dto);
            _context.HalfYears.Add(entity);
            _context.SaveChanges();
            _logger.LogInformation("Полугодие успешно создано (Id={Id})", entity.Id);
            return _mapper.Map<HalfYearDto>(entity);
        }

        public HalfYearDto? Update(int id, HalfYearDto dto)
        {
            _logger.LogInformation("Обновление полугодия с Id={Id}", id);
            var existing = _context.HalfYears.Include(h => h.Sessions).FirstOrDefault(h => h.Id == id);
            if (existing == null)
            {
                _logger.LogWarning("Полугодие для обновления не найдено (Id={Id})", id);
                return null;
            }

            existing.DateStart = dto.DateStart;
            existing.DateEnd = dto.DateEnd;
            _context.SaveChanges();
            _logger.LogInformation("Полугодие с Id={Id} успешно обновлено", id);
            return _mapper.Map<HalfYearDto>(existing);
        }

        public bool Delete(int id)
        {
            _logger.LogInformation("Удаление полугодия с Id={Id}", id);
            var entity = _context.HalfYears.FirstOrDefault(h => h.Id == id);
            if (entity == null)
            {
                _logger.LogWarning("Полугодие для удаления не найдено (Id={Id})", id);
                return false;
            }

            _context.HalfYears.Remove(entity);
            _context.SaveChanges();
            _logger.LogInformation("Полугодие с Id={Id} успешно удалено", id);
            return true;
        }
    }
}
