using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UniversityPersonalAccount.Data;
using UniversityPersonalAccount.Models.DTOs;
using UniversityPersonalAccount.Models.Entities;
using UniversityPersonalAccount.Services.Interfaces;

namespace UniversityPersonalAccount.Services
{
    public class CourseService : BaseCrudService<Course, CourseDto>, ICourseService
    {
        public CourseService(PersonalAccountDbContext context, IMapper mapper, ILogger<CourseService> logger)
            : base(context, mapper, logger)
        {
        }

        public override IEnumerable<CourseDto> GetAll()
        {
            _logger.LogInformation("Получение всех курсов с группами и студентами");
            var list = _context.Courses
                .Include(c => c.Groups)
                .Include(c => c.Students)
                .ToList();
            return _mapper.Map<IEnumerable<CourseDto>>(list);
        }

        public override CourseDto? GetById(int id)
        {
            var entity = _context.Courses
                .Include(c => c.Groups)
                .Include(c => c.Students)
                .FirstOrDefault(c => c.Id == id);
            return _mapper.Map<CourseDto?>(entity);
        }
    }
}
