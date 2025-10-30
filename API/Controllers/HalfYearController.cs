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
    public class HalfYearController : ControllerBase
    {
        private readonly IHalfYearService _service;
        private readonly ILogger<HalfYearController> _logger;

        public HalfYearController(IHalfYearService service, ILogger<HalfYearController> logger)
        {
            _service = service;
            _logger = logger;
        }
        /// <summary>
        /// Получение данных всех полугодий c учебными занятиями
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Получение всех полугодий");
            return Ok(_service.GetAll());
        }
        /// <summary>
        /// Получение данных полугодия с занятиями по Id
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }
        /// <summary>
        /// Добавление  данных полугодия с занятиями 
        /// </summary>
        [HttpPost]
        public IActionResult Create([FromBody] HalfYearDto dto)
        {
            _logger.LogInformation("Создание полугодия с {DateStart}", dto.DateStart);
            var created = _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        /// <summary>
        /// Изменение  данных полугодия с занятиями по Id
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] HalfYearDto dto)
        {
            var updated = _service.Update(id, dto);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }
        /// <summary>
        /// Удаление  данных  полгуодия с занятиями по  Id
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _service.Delete(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
