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
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _service;
        private readonly ILogger<SessionController> _logger;

        public SessionController(ISessionService service, ILogger<SessionController> logger)
        {
            _service = service;
            _logger = logger;
        }
        /// <summary>
        /// Получение  данных сессии с началом и концном пары
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Получение всех сессий");
            return Ok(_service.GetAll());
        }
        /// <summary>
        /// Получение  данных сессии с началом и концном пары по Id
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);
            return result == null ? NotFound() : Ok(result);
        }
        /// <summary>
        /// Добавление  данных сессии с началом и концном пары по Id
        /// </summary>
        [HttpPost]
        public IActionResult Create([FromBody] SessionDto dto)
        {
            var created = _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
         /// <summary>
        /// Обновление данных сессии с началом и концном пары по Id
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] SessionDto dto)
        {
            var updated = _service.Update(id, dto);
            return updated == null ? NotFound() : Ok(updated);
        }
         /// <summary>
        /// Удаление данных сессии с началом и концном пары по Id
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _service.Delete(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
