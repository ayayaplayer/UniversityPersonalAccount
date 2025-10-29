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

        public HalfYearController(IHalfYearService service)
        {
            _service = service;
        }
        /// <summary>
        /// Получение данных всех полугодий c учебными занятиями
        /// </summary>
        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());


        /// <summary>
        /// Получение данных полугодия с занятиями по Id
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);
            return result == null ? NotFound() : Ok(result);
        }
        /// <summary>
        /// Добавление  данных полугодия с занятиями 
        /// </summary>
        [HttpPost]
        public IActionResult Create([FromBody] HalfYearDto dto)
        {
            var result = _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        /// <summary>
        /// Изменение  данных полугодия с занятиями по Id
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] HalfYearDto dto)
        {
            var result = _service.Update(id, dto);
            return result == null ? NotFound() : Ok(result);
        }
        /// <summary>
        /// Удаление  данных  полгуодия с занятиями по  Id
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return _service.Delete(id) ? NoContent() : NotFound();
        }
    }
}
