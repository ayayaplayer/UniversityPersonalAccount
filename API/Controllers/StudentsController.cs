using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using UniversityPersonalAccount.Models.Entities;
using UniversityPersonalAccount.Models.DTOs;
using UniversityPersonalAccount.Data;

namespace UniversityPersonalAccount.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly PersonalAccountDbContext _context;
        private readonly IMapper _mapper;

        public StudentsController(PersonalAccountDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
                return NotFound();

            var studentDto = _mapper.Map<StudentDto>(student);
            return Ok(studentDto);
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = _context.Students.ToList();
            var studentDtos = _mapper.Map<List<StudentDto>>(students);
            return Ok(studentDtos);
        }

        [HttpPost]
        public IActionResult CreateStudent(StudentCreateDto dto)
        {
            var student = _mapper.Map<Student>(dto);
            _context.Students.Add(student);
            _context.SaveChanges();
            
            var studentDto = _mapper.Map<StudentDto>(student);
            return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, studentDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, StudentUpdateDto dto)
        {
            var student = _context.Students.Find(id);
            if (student == null)
                return NotFound();

            _mapper.Map(dto, student);
            _context.SaveChanges();

            return Ok(_mapper.Map<StudentDto>(student));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
                return NotFound();

            _context.Students.Remove(student);
            _context.SaveChanges();

            return NoContent();
        }
    }
}