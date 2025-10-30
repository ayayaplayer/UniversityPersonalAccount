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
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _service;
        private readonly ILogger<GroupController> _logger;

        public GroupController(IGroupService service, ILogger<GroupController> logger)
        {
            _service = service;
            _logger = logger;
        }
        /// <summary>
        /// Получение данных всех групп и студентов в них
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Получение списка групп");
            return Ok(_service.GetAll());
        }
        /// <summary>
        /// Получение данных группы и студентов в ней по Id
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);
            if (result == null)
            {
                _logger.LogWarning("Группа с Id={Id} не найдена", id);
                return NotFound();
            }

            return Ok(result);
        }
        /// <summary>
        /// Добавление данных группы и студентов в нее
        /// </summary>
        [HttpPost]
        public IActionResult Create([FromBody] GroupDto dto)
        {
            _logger.LogInformation("Создание группы {Name}", dto.GroupName);
            var created = _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        /// <summary>
        /// Изменение данных группы и студетов в ней
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] GroupDto dto)
        {
            _logger.LogInformation("Обновление группы Id={Id}", id);
            var updated = _service.Update(id, dto);
            if (updated == null)
            {
                _logger.LogWarning("Группа с Id={Id} не найдена", id);
                return NotFound();
            }

            return Ok(updated);
        }
        /// <summary>
        /// Удаление данных группы и студетов в ней
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("Удаление группы Id={Id}", id);
            var deleted = _service.Delete(id);
            if (!deleted)
            {
                _logger.LogWarning("Группа с Id={Id} не найдена для удаления", id);
                return NotFound();
            }

            return NoContent();
        }
    }
}
