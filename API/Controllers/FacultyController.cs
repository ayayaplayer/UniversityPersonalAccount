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
    public class FacultyController : ControllerBase
    {
        private readonly PersonalAccountDbContext _context;
        private readonly IMapper _mapper;

        public FacultyController(PersonalAccountDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        [HttpGet("{id}")]
        public IActionResult GetFacultyById(int id)
        {
            var faculty = _context.Faculties.Find(id);
            if (faculty == null)
                return NotFound();

            var facultyDto = _mapper.Map<FacultyDto>(faculty);
            return Ok(facultyDto);
        }



        [HttpGet]
        public IActionResult GetAllFaculties()
        {
            var faculties = _context.Faculties.Include(g => g.Groups).ToList();
            var facultiesDtos = _mapper.Map<List<FacultyDto>>(faculties);
            return Ok(facultiesDtos);


        }


        [HttpPost]
        public IActionResult CreateFaculty(FacultyCreateDto dto)
        {
            var faculty = _mapper.Map<Faculty>(dto);
            _context.Faculties.Add(faculty);
            _context.SaveChanges();

            var facultyDto = _mapper.Map<FacultyDto>(faculty);
            return CreatedAtAction(nameof(GetFacultyById), new { id = faculty.Id }, facultyDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFaculty(int id, FacultyUpdateDto dto)
        {
            var faculty = _context.Faculties.Find(id);
            if (faculty == null)
                return NotFound();

            _mapper.Map(dto, faculty);
            _context.SaveChanges();

            return Ok(_mapper.Map<FacultyDto>(faculty));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFaculty(int id)
        {
            var faculty = _context.Faculties.Find(id);
            if (faculty == null)
                return NotFound();

            _context.Faculties.Remove(faculty);
            _context.SaveChanges();

            return NoContent();
        }


    }
}