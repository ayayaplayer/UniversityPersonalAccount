using UniversityPersonalAccount.Data;
using UniversityPersonalAccount.Models.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UniversityPersonalAccount.Models.DTOs.Student;
using UniversityPersonalAccount.Services.Interfaces;

namespace UniversityPersonalAccount.Services.StudentService;
public class StudentService : IStudentService
    {
        private readonly PersonalAccountDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<StudentService> _logger;

        public StudentService(PersonalAccountDbContext context, IMapper mapper, ILogger<StudentService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public IEnumerable<Student> GetAll()
        {
            try
            {
                return _context.Students.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при получении всех студентов");
                throw;
            }
        }

        public Student? GetById(int id)
        {
            try
            {
                return _context.Students                    
                    .FirstOrDefault(s => s.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ошибка при получении студента с ID {id}");
                throw;
            }
        }

        public Student Create(StudentCreateDto dto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dto.Name) || string.IsNullOrWhiteSpace(dto.Surname))
                    throw new ArgumentException("Имя и фамилия студента не могут быть пустыми");

                if (string.IsNullOrWhiteSpace(dto.Email))
                    throw new ArgumentException("Email не может быть пустым");

                

                var student = _mapper.Map<Student>(dto);
                _context.Students.Add(student);
                _context.SaveChanges();

                _logger.LogInformation($"Студент '{dto.Name} {dto.Surname}' успешно создан");
                return student;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при создании студента");
                throw;
            }
        }

        public void Update(StudentUpdateDto dto)
        {
            try
            {
                var student = _context.Students.Find(dto.Id);
                if (student == null)
                    throw new KeyNotFoundException($"Студент с ID {dto.Id} не найден");

                _mapper.Map(dto, student);
                _context.Students.Update(student);
                _context.SaveChanges();

                _logger.LogInformation($"Студент с ID {dto.Id} успешно обновлен");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ошибка при обновлении студента {dto.Id}");
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var student = _context.Students.Find(id);
                if (student == null)
                    throw new KeyNotFoundException($"Студент с ID {id} не найден");

                _context.Students.Remove(student);
                _context.SaveChanges();

                _logger.LogInformation($"Студент с ID {id} успешно удален");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ошибка при удалении студента {id}");
                throw;
            }
        }
    }