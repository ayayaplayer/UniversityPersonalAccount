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

        public GroupController(IGroupService service)
        {
            _service = service;
        }
        /// <summary>
        /// Получение данных всех групп и студентов в них
        /// </summary>
        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());
        /// <summary>
        /// Получение данных группы и студентов в ней по Id
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);
            return result == null ? NotFound() : Ok(result);
        }

        /// <summary>
        /// Добавление данных группы и студентов в нее
        /// </summary>
        [HttpPost]
        public IActionResult Create([FromBody] GroupDto dto)
        {
            var result = _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        /// <summary>
        /// Изменение данных группы и студетов в ней
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] GroupDto dto)
        {
            var result = _service.Update(id, dto);
            return result == null ? NotFound() : Ok(result);
        }


        /// <summary>
        /// Удаление данных группы и студетов в ней
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return _service.Delete(id) ? NoContent() : NotFound();
        }
    }
}
