using AutoMapper;
using UniversityPersonalAccount.Data;
using UniversityPersonalAccount.Models.Entities;
using UniversityPersonalAccount.Models.DTOs;
using UniversityPersonalAccount.Services.Interfaces;
using Microsoft.EntityFrameworkCore;




namespace UniversityPersonalAccount.Services.CourseService
    {

        public class CourseWithGroupService : ICourseWithGroupService
        {
            private readonly PersonalAccountDbContext _context;
            private readonly IMapper _mapper;
            private readonly ILogger<CourseWithGroupService> _logger;

            public CourseWithGroupService(PersonalAccountDbContext context, IMapper mapper, ILogger<CourseWithGroupService> logger)
            {
                _context = context;
                _mapper = mapper;
                _logger = logger;
            }

            public IEnumerable<Course> GetAll()
            {
                try
                {
                    return _context.Courses
                    .Include( g => g.Students)
                    .Include( g => g.Groups ) 
                    .ToList();
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
                        .Include(g => g.Groups)
                        .FirstOrDefault(c => c.Id == id);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Ошибка при получении курса с ID {id}");
                    throw;
                }
            }
        }
    }
