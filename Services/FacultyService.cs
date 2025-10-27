using UniversityPersonalAccount.Data;
using UniversityPersonalAccount.Models.Entities;
using UniversityPersonalAccount.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UniversityPersonalAccount.Models.DTOs.Faculty;

namespace UniversityPersonalAccount.Services;



public class FacultyService : IFacultyService
{
    private readonly PersonalAccountDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger<FacultyService> _logger;

    public FacultyService(PersonalAccountDbContext context, IMapper mapper, ILogger<FacultyService> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    public IEnumerable<Faculty> GetAll()
    {
        try
        {
            return _context.Faculties.ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при получении всех факультетов");
            throw;
        }
    }

    public Faculty? GetById(int id)
    {
        try
        {
            return _context.Faculties               
                .FirstOrDefault(f => f.Id == id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Ошибка при получении факультета с ID {id}");
            throw;
        }
    }

    public Faculty Create(FacultyCreateDto dto)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new ArgumentException("Название факультета не может быть пустым");

            var faculty = _mapper.Map<Faculty>(dto);
            _context.Faculties.Add(faculty);
            _context.SaveChanges();

            _logger.LogInformation($"Факультет '{dto.Name}' успешно создан");
            return faculty;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при создании факультета");
            throw;
        }
    }

    public void Update(FacultyUpdateDto dto)
    {
        try
        {
            var faculty = _context.Faculties.Find(dto.Id);
            if (faculty == null)
                throw new KeyNotFoundException($"Факультет с ID {dto.Id} не найден");

            _mapper.Map(dto, faculty);
            _context.Faculties.Update(faculty);
            _context.SaveChanges();

            _logger.LogInformation($"Факультет с ID {dto.Id} успешно обновлен");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Ошибка при обновлении факультета {dto.Id}");
            throw;
        }
    }

    public void Delete(int id)
    {
        try
        {
            var faculty = _context.Faculties.Find(id);
            if (faculty == null)
                throw new KeyNotFoundException($"Факультет с ID {id} не найден");

            _context.Faculties.Remove(faculty);
            _context.SaveChanges();

            _logger.LogInformation($"Факультет с ID {id} успешно удален");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Ошибка при удалении факультета {id}");
            throw;
        }
    }
}
