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

        public SessionController(ISessionService service)
        {
            _service = service;
        }
        /// <summary>
        /// Получение данных учебных занятий с порядковым номером пары, началом занятия,концом занятия 
        /// </summary>
        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());



        /// <summary>
        /// Получение данных учебных занятий с порядковым номером пары, началом занятия,концом занятия по Id 
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);
            return result == null ? NotFound() : Ok(result);
        }

        /// <summary>
        /// Добавление данных учебных занятий с порядковым номером пары, началом занятия,концом занятия 
        /// </summary>
        [HttpPost]
        public IActionResult Create([FromBody] SessionDto dto)
        {
            var result = _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        /// <summary>
        /// Обновление данных учебного занятия с порядковым номером пары, началом занятия,концом занятия по Id
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] SessionDto dto)
        {
            var result = _service.Update(id, dto);
            return result == null ? NotFound() : Ok(result);
        }
        /// <summary>
        /// Удаление данных учебного занятия с порядковым номером пары, началом занятия,концом занятия по Id 
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return _service.Delete(id) ? NoContent() : NotFound();
        }
    }
}
