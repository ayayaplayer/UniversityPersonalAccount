using AutoMapper;
using Microsoft.Extensions.Logging;
using UniversityPersonalAccount.Data;
using UniversityPersonalAccount.Models.DTOs;
using UniversityPersonalAccount.Models.Entities;
using UniversityPersonalAccount.Services.Interfaces;

namespace UniversityPersonalAccount.Services
{
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

        public IEnumerable<StudentDto> GetAll()
        {
            _logger.LogInformation("Получение всех студентов");
            var students = _context.Students.ToList();
            return _mapper.Map<List<StudentDto>>(students);
        }

        public StudentDto? GetById(int id)
        {
            _logger.LogInformation("Получение студента Id={Id}", id);
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            return student == null ? null : _mapper.Map<StudentDto>(student);
        }

        public StudentDto Create(StudentDto dto)
        {
            _logger.LogInformation("Создание студента: {Name} {Surname}", dto.Name, dto.SurName);
            var entity = _mapper.Map<Student>(dto);
            _context.Students.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<StudentDto>(entity);
        }

        public StudentDto? Update(int id, StudentDto dto)
        {
            _logger.LogInformation("Обновление студента Id={Id}", id);
            var entity = _context.Students.FirstOrDefault(s => s.Id == id);
            if (entity == null) return null;

            entity.Name = dto.Name;
            entity.Surname = dto.SurName;
            entity.Email = dto.Email;

            _context.SaveChanges();

            return _mapper.Map<StudentDto>(entity);
        }

        public bool Delete(int id)
        {
            _logger.LogInformation("Удаление студента Id={Id}", id);
            var entity = _context.Students.FirstOrDefault(s => s.Id == id);
            if (entity == null) return false;

            _context.Students.Remove(entity);
            _context.SaveChanges();
            return true;
        }
    }
}
