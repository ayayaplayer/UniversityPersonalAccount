using Microsoft.AspNetCore.Mvc;
using UniversityPersonalAccount.Models.DTOs;
using UniversityPersonalAccount.Services.Interfaces;

namespace UniversityPersonalAccount.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacultyController : ControllerBase
    {
        private readonly IFacultyService _service;
        private readonly ILogger<FacultyController> _logger;

        public FacultyController(IFacultyService service, ILogger<FacultyController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Получение списка факультетов");
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);
            if (result == null)
            {
                _logger.LogWarning("Факультет с Id={Id} не найден", id);
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] FacultyDto dto)
        {
            _logger.LogInformation("Создание факультета {Name}", dto.Name);
            var created = _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] FacultyDto dto)
        {
            _logger.LogInformation("Обновление факультета Id={Id}", id);
            var updated = _service.Update(id, dto);
            if (updated == null)
            {
                _logger.LogWarning("Факультет с Id={Id} не найден", id);
                return NotFound();
            }

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("Удаление факультета Id={Id}", id);
            var deleted = _service.Delete(id);
            if (!deleted)
            {
                _logger.LogWarning("Факультет с Id={Id} не найден для удаления", id);
                return NotFound();
            }

            return NoContent();
        }
    }
}
