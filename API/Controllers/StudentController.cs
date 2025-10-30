using Microsoft.AspNetCore.Mvc;
using UniversityPersonalAccount.Models.DTOs;
using UniversityPersonalAccount.Services.Interfaces;

namespace UniversityPersonalAccount.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Produces("application/json")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;
        private readonly ILogger<StudentController> _logger;

        public StudentController(IStudentService service, ILogger<StudentController> logger)
        {
            _service = service;
            _logger = logger;
        }
        /// <summary>
        /// Получение данных студента
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Получение всех студентов");
            return Ok(_service.GetAll());
        }
        /// <summary>
        /// Получение данных студента по Id
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);
            return result == null ? NotFound() : Ok(result);
        }
        /// <summary>
        /// Получение данных студента по Id
        /// </summary>
        [HttpPost]
        public IActionResult Create([FromBody] StudentDto dto)
        {
            _logger.LogInformation("Создание студента {Name} {Surname}", dto.Name, dto.Surname);
            var created = _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        /// <summary>
        /// Получение данных студента по Id
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] StudentDto dto)
        {
            var updated = _service.Update(id, dto);
            return updated == null ? NotFound() : Ok(updated);
        }
        /// <summary>
        /// Получение данных студента по Id
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _service.Delete(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
