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
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _service;
        private readonly ILogger<CourseController> _logger;

        public CourseController(ICourseService service, ILogger<CourseController> logger)
        {
            _service = service;
            _logger = logger;
        }
        /// <summary>
        /// Получение данных о всех курсов
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Получение списка курсов");
            return Ok(_service.GetAll());
        }
        /// <summary>
        /// Получение данных курса по  Id
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);
            if (result == null)
            {
                _logger.LogWarning("Курс с Id={Id} не найден", id);
                return NotFound();
            }

            return Ok(result);
        }
        /// <summary>
        /// Добавление данных о курсе 
        /// </summary>
        [HttpPost]
        public IActionResult Create([FromBody] CourseDto dto)
        {
            _logger.LogInformation("Создание курса {Name}", dto.CourseName);
            var created = _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        /// <summary>
        /// Изменение данных курса по  Id
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CourseDto dto)
        {
            _logger.LogInformation("Обновление курса Id={Id}", id);
            var updated = _service.Update(id, dto);
            if (updated == null)
            {
                _logger.LogWarning("Курс с Id={Id} не найден", id);
                return NotFound();
            }

            return Ok(updated);
        }
        /// <summary>
        /// Удаление данных курса по  Id
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("Удаление курса Id={Id}", id);
            var deleted = _service.Delete(id);
            if (!deleted)
            {
                _logger.LogWarning("Курс с Id={Id} не найден для удаления", id);
                return NotFound();
            }

            return NoContent();
        }
    }
}
