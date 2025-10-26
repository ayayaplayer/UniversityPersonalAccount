using UniversityPersonalAccount.Data;
using UniversityPersonalAccount.Models.Entities;
using UniversityPersonalAccount.Models.DTOs;
using UniversityPersonalAccount.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace UniversityPersonalAccount.Services;




public class HalfYearService : IHalfYearService
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

        public IEnumerable<HalfYear> GetAll()
        {
            try
            {
                return _context.HalfYears.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при получении всех полугодий");
                throw;
            }
        }

        public HalfYear? GetById(int id)
        {
            try
            {
                return _context.HalfYears
                    .Include(h => h.Sessions)
                    .FirstOrDefault(h => h.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ошибка при получении полугодия с ID {id}");
                throw;
            }
        }

        public HalfYear Create(HalfYearCreateDto dto)
        {
            try
            {
                if (dto.DateEnd <= dto.DateStart)
                    throw new ArgumentException("Дата окончания должна быть позже даты начала");

                var halfYear = _mapper.Map<HalfYear>(dto);
                _context.HalfYears.Add(halfYear);
                _context.SaveChanges();

                _logger.LogInformation($"Полугодие с {dto.DateStart} по {dto.DateEnd} успешно создано");
                return halfYear;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при создании полугодия");
                throw;
            }
        }

        public void Update(HalfYearUpdateDto dto)
        {
            try
            {
                var halfYear = _context.HalfYears.Find(dto.Id);
                if (halfYear == null)
                    throw new KeyNotFoundException($"Полугодие с ID {dto.Id} не найдено");

                if (dto.DateEnd <= dto.DateStart)
                    throw new ArgumentException("Дата окончания должна быть позже даты начала");

                _mapper.Map(dto, halfYear);
                _context.HalfYears.Update(halfYear);
                _context.SaveChanges();

                _logger.LogInformation($"Полугодие с ID {dto.Id} успешно обновлено");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ошибка при обновлении полугодия {dto.Id}");
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var halfYear = _context.HalfYears.Find(id);
                if (halfYear == null)
                    throw new KeyNotFoundException($"Полугодие с ID {id} не найдено");

                _context.HalfYears.Remove(halfYear);
                _context.SaveChanges();

                _logger.LogInformation($"Полугодие с ID {id} успешно удалено");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ошибка при удалении полугодия {id}");
                throw;
            }
        }
    }