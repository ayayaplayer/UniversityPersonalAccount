using Microsoft.AspNetCore.Mvc;
using UniversityPersonalAccount.Services.Interfaces;
using UniversityPersonalAccount.Models.DTOs.Course;

namespace UniversityPersonalAccount.API.Controllers.Course
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseWithGroupController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseWithGroupController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CourseGetAllDto>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<CourseGetAllDto>> GetAll()
        {
            var courses = _courseService.GetAll();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CourseGetByIdDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CourseGetByIdDto> GetById(int id)
        {
            var course = _courseService.GetById(id);
            if (course == null)
                return NotFound(new { message = $"Курс с ID {id} не найден" });

            return Ok(course);
        }

    }
}

