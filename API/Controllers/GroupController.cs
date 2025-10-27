using Microsoft.AspNetCore.Mvc;
using UniversityPersonalAccount.Models.DTOs.Group;
using UniversityPersonalAccount.Services.Interfaces;

namespace UniversityPersonalAccount.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GroupGetAllDto>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<GroupGetAllDto>> GetAll()
        {
            var groups = _groupService.GetAll();
            return Ok(groups);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GroupGetByIdDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<GroupGetByIdDto> GetById(int id)
        {
            var group = _groupService.GetById(id);
            if (group == null)
                return NotFound(new { message = $"Курс с ID {id} не найден" });

            return Ok(group);
        }

        [HttpPost]
        [ProducesResponseType(typeof(GroupGetByIdDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<GroupGetByIdDto> Create([FromBody] GroupCreateDto createDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var group = _groupService.Create(createDto);
                return CreatedAtAction(nameof(GetById), new { id = group.Id }, group);
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
        public IActionResult Update(int id, [FromBody] GroupUpdateDto updateDto)
        {
            if (id != updateDto.Id)
                return BadRequest(new { message = "ID в URL не совпадает с ID в теле запроса" });

            try
            {
                _groupService.Update(updateDto);
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
                _groupService.Delete(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
