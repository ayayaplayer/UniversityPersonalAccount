using Microsoft.AspNetCore.Mvc;
using UniversityPersonalAccount.Models.DTOs.Session;
using UniversityPersonalAccount.Services.Interfaces;

namespace UniversityPersonalAccount.API.Controllers.Session
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _sessionService;

        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SessionGetAllDto>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<SessionGetAllDto>> GetAll()
        {
            var sessions = _sessionService.GetAll();
            return Ok(sessions);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SessionGetByIdDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<SessionGetByIdDto> GetById(int id)
        {
            var session = _sessionService.GetById(id);
            if (session == null)
                return NotFound(new { message = $"Курс с ID {id} не найден" });

            return Ok(session);
        }

        [HttpPost]
        [ProducesResponseType(typeof(SessionGetByIdDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<SessionGetByIdDto> Create([FromBody] SessionCreateDto createDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var session = _sessionService.Create(createDto);
                return CreatedAtAction(nameof(GetById), new { id = session.Id }, session);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update(int id, [FromBody] SessionUpdateDto updateDto)
        {
            if (id != updateDto.Id)
                return BadRequest(new { message = "ID в URL не совпадает с ID в теле запроса" });

            try
            {
                _sessionService.Update(updateDto);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            try
            {
                _sessionService.Delete(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
