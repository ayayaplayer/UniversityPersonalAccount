using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityPersonalAccount.Data;
using UniversityPersonalAccount.Models.DTOs;
using UniversityPersonalAccount.Models.Entities;

namespace UniversityPersonalAccount.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly PersonalAccountDbContext _context;
        private readonly IMapper _mapper;

        public CourseController(PersonalAccountDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        [HttpGet("{id}")]
        public IActionResult GetCourseById(int id)
        {
            var course = _context.Courses.Find(id);
            if (course == null)
                return NotFound();

            var courseDto = _mapper.Map<CourseDto>(course);
            return Ok(courseDto);
        }



        [HttpGet]
        public IActionResult GetAllCourses()
        {
            var courses = _context.Courses.ToList();
            var coursesDtos = _mapper.Map<List<CourseDto>>(courses);
            return Ok(coursesDtos);


        }


        [HttpPost]
        public IActionResult CreateCourse(CourseCreateDto dto)
        {
            var course = _mapper.Map<Course>(dto);
            _context.Courses.Add(course);
            _context.SaveChanges();

            var courseDto = _mapper.Map<CourseDto>(course);
            return CreatedAtAction(nameof(GetCourseById), new { id = course.Id }, courseDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCourse(int id, CourseUpdateDto dto)
        {
            var course = _context.Courses.Find(id);
            if (course == null)
                return NotFound();

            _mapper.Map(dto, course);
            _context.SaveChanges();

            return Ok(_mapper.Map<CourseDto>(course));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            var course = _context.Courses.Find(id);
            if (course == null)
                return NotFound();

            _context.Courses.Remove(course);
            _context.SaveChanges();

            return NoContent();
        }


    }
}