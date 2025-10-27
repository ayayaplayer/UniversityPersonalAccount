using Microsoft.AspNetCore.Mvc;
using UniversityPersonalAccount.Models.DTOs.Course;
using UniversityPersonalAccount.Models.DTOs.Faculty;
using UniversityPersonalAccount.Services.Interfaces;

namespace UniversityPersonalAccount.API.Controllers.Faculty
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacultyController : ControllerBase
    {
        private readonly IFacultyService _facultyService;

        public FacultyController(IFacultyService facultyService)
        {
            _facultyService = facultyService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<FacultyGetAllDto>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<CourseGetAllDto>> GetAll()
        {
            var faculties = _facultyService.GetAll();
            return Ok(faculties);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FacultyGetByIdDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FacultyGetByIdDto> GetById(int id)
        {
            var faculty = _facultyService.GetById(id);
            if (faculty == null)
                return NotFound(new { message = $"Курс с ID {id} не найден" });

            return Ok(faculty);
        }

        [HttpPost]
        [ProducesResponseType(typeof(FacultyGetByIdDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<FacultyGetByIdDto> Create([FromBody] FacultyCreateDto createDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var faculty = _facultyService.Create(createDto);
                return CreatedAtAction(nameof(GetById), new { id = faculty.Id }, faculty);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update(int id, [FromBody] FacultyUpdateDto updateDto)
        {
            if (id != updateDto.Id)
                return BadRequest(new { message = "ID в URL не совпадает с ID в теле запроса" });

            try
            {
                _facultyService.Update(updateDto);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            try
            {
                _facultyService.Delete(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
