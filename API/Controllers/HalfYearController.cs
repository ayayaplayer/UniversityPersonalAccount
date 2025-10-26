using Microsoft.AspNetCore.Mvc;
using UniversityPersonalAccount.Models.DTOs;
using UniversityPersonalAccount.Services.Interfaces;

namespace UniversityPersonalAccount.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HalfYearController : ControllerBase
    {
        private readonly IHalfYearService _halfyearService;

        public HalfYearController(IHalfYearService halfyearService)
        {
            _halfyearService = halfyearService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<HalfYearGetAllDto>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<HalfYearGetAllDto>> GetAll()
        {
            var halfyears = _halfyearService.GetAll();
            return Ok(halfyears);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(HalfYearGetByIdDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<HalfYearGetByIdDto> GetById(int id)
        {
            var halfyear = _halfyearService.GetById(id);
            if (halfyear == null)
                return NotFound(new { message = $"Курс с ID {id} не найден" });

            return Ok(halfyear);
        }

        [HttpPost]
        [ProducesResponseType(typeof(HalfYearGetByIdDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<HalfYearGetByIdDto> Create([FromBody] HalfYearCreateDto createDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var halfyear = _halfyearService.Create(createDto);
                return CreatedAtAction(nameof(GetById), new { id = halfyear.Id }, halfyear);
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
        public IActionResult Update(int id, [FromBody] HalfYearUpdateDto updateDto)
        {
            if (id != updateDto.Id)
                return BadRequest(new { message = "ID в URL не совпадает с ID в теле запроса" });

            try
            {
                _halfyearService.Update(updateDto);
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
                _halfyearService.Delete(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
