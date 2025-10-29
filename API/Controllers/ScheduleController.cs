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

        public ScheduleController(IScheduleService service)
        {
            _service = service;
        }
        /// <summary>
        /// Получение данных всех рассписаний с названием предмета, номером аудитории, группой 
        /// </summary>
        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());




        /// <summary>
        /// Получение данных всех рассписаний с названием предмета, номером аудитории, группой по Id 
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);
            return result == null ? NotFound() : Ok(result);
        }
        /// <summary>
        /// Добавление  данных рассписаний с названием предмета, номером аудитории, группой 
        /// </summary>
        [HttpPost]
        public IActionResult Create([FromBody] ScheduleDto dto)
        {
            var result = _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        /// <summary>
        /// Обновление данных рассписания с названием предмета, номером аудитории, группой по Id
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ScheduleDto dto)
        {
            var result = _service.Update(id, dto);
            return result == null ? NotFound() : Ok(result);
        }
        /// <summary>
        /// Удаление данных рассписания с названием предмета, номером аудитории, группой по Id 
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return _service.Delete(id) ? NoContent() : NotFound();
        }
    }
}
