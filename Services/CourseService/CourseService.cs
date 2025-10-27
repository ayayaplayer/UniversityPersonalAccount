using UniversityPersonalAccount.Data;
using UniversityPersonalAccount.Models.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UniversityPersonalAccount.Models.DTOs.Course;
using Microsoft.OpenApi.Extensions;
using UniversityPersonalAccount.Services.Interfaces;

namespace UniversityPersonalAccount.Services.CourseService
{

    public class CourseService : ICourseService
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

        public IEnumerable<Course> GetAll()
        {
            try
            {
                return _context.Courses.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при получении всех курсов");
                throw;
            }
        }

        public Course? GetById(int id)
        {
            try
            {
                return _context.Courses        
                    .FirstOrDefault(c => c.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ошибка при получении курса с ID {id}");
                throw;
            }
        }

        public Course Create(CourseCreateDto dto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dto.CourseName.ToString()))
                    throw new ArgumentException("Название курса не может быть пустым");

                var course = _mapper.Map<Course>(dto);
                _context.Courses.Add(course);
                _context.SaveChanges();

                _logger.LogInformation($"Курс '{dto.CourseName.GetDisplayName}' успешно создан");
                return course;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при создании курса");
                throw;
            }
        }

        public void Update(CourseUpdateDto dto)
        {
            try
            {
                var course = _context.Courses.Find(dto.Id);
                if (course == null)
                    throw new KeyNotFoundException($"Курс с ID {dto.Id} не найден");

                _mapper.Map(dto, course);
                _context.Courses.Update(course);
                _context.SaveChanges();

                _logger.LogInformation($"Курс с ID {dto.Id} успешно обновлен");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ошибка при обновлении курса {dto.Id}");
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var course = _context.Courses.Find(id);
                if (course == null)
                    throw new KeyNotFoundException($"Курс с ID {id} не найден");

                _context.Courses.Remove(course);
                _context.SaveChanges();

                _logger.LogInformation($"Курс с ID {id} успешно удален");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ошибка при удалении курса {id}");
                throw;
            }
        }
    }

}