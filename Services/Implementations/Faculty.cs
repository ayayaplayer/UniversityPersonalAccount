using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UniversityPersonalAccount.Data;
using UniversityPersonalAccount.Models.DTOs;
using UniversityPersonalAccount.Models.Entities;
using UniversityPersonalAccount.Services.Interfaces;

namespace UniversityPersonalAccount.Services
{
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

        public IEnumerable<FacultyDto> GetAll()
        {
            _logger.LogInformation("Получение всех факультетов");
            var faculties = _context.Faculties.Include(f => f.Groups).ToList();
            return _mapper.Map<List<FacultyDto>>(faculties);
        }

        public FacultyDto? GetById(int id)
        {
            _logger.LogInformation("Получение факультета Id={Id}", id);
            var faculty = _context.Faculties.Include(f => f.Groups).FirstOrDefault(f => f.Id == id);
            return faculty == null ? null : _mapper.Map<FacultyDto>(faculty);
        }

        public FacultyDto Create(FacultyDto dto)
        {
            _logger.LogInformation("Создание нового факультета: {Name}", dto.Name);
            var entity = _mapper.Map<Faculty>(dto);
            _context.Faculties.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<FacultyDto>(entity);
        }

        public FacultyDto? Update(int id, FacultyDto dto)
        {
            _logger.LogInformation("Обновление факультета Id={Id}", id);
            var entity = _context.Faculties.FirstOrDefault(f => f.Id == id);
            if (entity == null) return null;

            entity.Name = dto.Name;
            _context.SaveChanges();

            return _mapper.Map<FacultyDto>(entity);
        }

        public bool Delete(int id)
        {
            _logger.LogInformation("Удаление факультета Id={Id}", id);
            var entity = _context.Faculties.FirstOrDefault(f => f.Id == id);
            if (entity == null) return false;

            _context.Faculties.Remove(entity);
            _context.SaveChanges();
            return true;
        }
    }
}
