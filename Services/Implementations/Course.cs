using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UniversityPersonalAccount.Data;
using UniversityPersonalAccount.Models.DTOs;
using UniversityPersonalAccount.Models.Entities;
using UniversityPersonalAccount.Services.Interfaces;

namespace UniversityPersonalAccount.Services
{
    public class CourseService  : ICourseService

    {
        private readonly PersonalAccountDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<CourseService> _logger;

        public CourseService(PersonalAccountDbContext context, IMapper mapper, ILogger<CourseService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public IEnumerable<CourseDto> GetAll()
        {
            _logger.LogInformation("Получение всех курсов");
            var courses = _context.Courses.Include(c => c.Groups).Include(c => c.Students).ToList();
            return _mapper.Map<IEnumerable<CourseDto>>(courses);
        }

        public CourseDto? GetById(int id)
        {
            _logger.LogInformation("Получение курса с Id={Id}", id);
            var course = _context.Courses.Include(c => c.Groups).Include(c => c.Students).FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                _logger.LogWarning("Курс с Id={Id} не найден", id);
                return null;
            }

            return _mapper.Map<CourseDto>(course);
        }

        public CourseDto Create(CourseDto dto)
        {
            _logger.LogInformation("Создание нового курса: {CourseName}", dto.CourseName);
            var entity = _mapper.Map<Course>(dto);
            _context.Courses.Add(entity);
            _context.SaveChanges();
            _logger.LogInformation("Курс успешно создан с Id={Id}", entity.Id);
            return _mapper.Map<CourseDto>(entity);
        }

        public CourseDto? Update(int id, CourseDto dto)
        {
            _logger.LogInformation("Обновление курса с Id={Id}", id);
            var existing = _context.Courses.Include(c => c.Groups).Include(c => c.Students).FirstOrDefault(c => c.Id == id);
            if (existing == null)
            {
                _logger.LogWarning("Курс для обновления не найден (Id={Id})", id);
                return null;
            }

            existing.DegreeLevel = dto.DegreeLevel;
            if (Enum.TryParse(dto.CourseName, out CourseName name))
                existing.CourseName = name;

            _context.SaveChanges();
            _logger.LogInformation("Курс с Id={Id} успешно обновлён", id);
            return _mapper.Map<CourseDto>(existing);
        }

        public bool Delete(int id)
        {
            _logger.LogInformation("Удаление курса с Id={Id}", id);
            var entity = _context.Courses.FirstOrDefault(c => c.Id == id);
            if (entity == null)
            {
                _logger.LogWarning("Курс для удаления не найден (Id={Id})", id);
                return false;
            }

            _context.Courses.Remove(entity);
            _context.SaveChanges();
            _logger.LogInformation("Курс с Id={Id} успешно удалён", id);
            return true;
        }
    }
}
