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
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _service;
        private readonly ILogger<ScheduleController> _logger;

        public ScheduleController(IScheduleService service, ILogger<ScheduleController> logger)
        {
            _service = service;
            _logger = logger;
        }
        /// <summary>
        /// Получение данных всех рассписаний с названием предмета, номером аудитории, группой 
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Получение расписаний");
            return Ok(_service.GetAll());
        }
         /// <summary>
        /// Получение данных всех рассписаний с названием предмета, номером аудитории, группой по Id 
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
        /// Добавление  данных рассписаний с названием предмета, номером аудитории, группой 
        /// </summary>
        [HttpPost]
        public IActionResult Create([FromBody] ScheduleDto dto)
        {
            _logger.LogInformation("Создание расписания {Subject}", dto.SubjectName);
            var created = _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        /// <summary>
        /// Обновление данных рассписания с названием предмета, номером аудитории, группой по Id
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ScheduleDto dto)
        {
            var updated = _service.Update(id, dto);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }
        /// <summary>
        /// Удаление данных рассписания с названием предмета, номером аудитории, группой по Id 
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _service.Delete(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
