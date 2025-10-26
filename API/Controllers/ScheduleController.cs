using Microsoft.AspNetCore.Mvc;
using UniversityPersonalAccount.Models.DTOs;
using UniversityPersonalAccount.Services.Interfaces;

namespace UniversityPersonalAccount.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ScheduleGetAllDto>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ScheduleGetAllDto>> GetAll()
        {
            var schedules = _scheduleService.GetAll();
            return Ok(schedules);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ScheduleGetByIdDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ScheduleGetByIdDto> GetById(int id)
        {
            var schedule = _scheduleService.GetById(id);
            if (schedule == null)
                return NotFound(new { message = $"Курс с ID {id} не найден" });

            return Ok(schedule);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ScheduleGetByIdDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ScheduleGetByIdDto> Create([FromBody] ScheduleCreateDto createDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var schedule = _scheduleService.Create(createDto);
                return CreatedAtAction(nameof(GetById), new { id = schedule.Id }, schedule);
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
        public IActionResult Update(int id, [FromBody] ScheduleUpdateDto updateDto)
        {
            if (id != updateDto.Id)
                return BadRequest(new { message = "ID в URL не совпадает с ID в теле запроса" });

            try
            {
                _scheduleService.Update(updateDto);
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
                _scheduleService.Delete(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
