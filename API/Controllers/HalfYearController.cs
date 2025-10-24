using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityPersonalAccount.Data;
using UniversityPersonalAccount.Models.DTOs;
using UniversityPersonalAccount.Models.Entities;

namespace UniversityPersonalAccount.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HalfYearController : ControllerBase
    {
        private readonly PersonalAccountDbContext _context;
        private readonly IMapper _mapper;

        public HalfYearController(PersonalAccountDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        [HttpGet("{id}")]
        public IActionResult GetHalfYearById(int id)
        {
            var halfyear = _context.HalfYears.Find(id);
            if (halfyear == null)
                return NotFound();

            var halfyearDto = _mapper.Map<HalfYearDto>(halfyear);
            return Ok(halfyearDto);
        }



        [HttpGet]
        public IActionResult GetAllHalfYears()
        {
            var halfyears = _context.HalfYears.ToList();
            var halfyearDtos = _mapper.Map<List<HalfYearDto>>(halfyears);
            return Ok(halfyearDtos);
        }


        [HttpPost]
        public IActionResult CreateHalfYear(HalfYearCreateDto dto)
        {
            var halfyear = _mapper.Map<HalfYear>(dto);
            _context.HalfYears.Add(halfyear);
            _context.SaveChanges();

            var halfyearDto = _mapper.Map<HalfYearDto>(halfyear);
            return CreatedAtAction(nameof(GetHalfYearById), new { id = halfyear.Id }, halfyearDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateHalfYear(int id, HalfYearUpdateDto dto)
        {
            var halfyear = _context.HalfYears.Find(id);
            if (halfyear == null)
                return NotFound();

            _mapper.Map(dto, halfyear);
            _context.SaveChanges();

            return Ok(_mapper.Map<HalfYearDto>(halfyear));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteHalfYear(int id)
        {
            var halfYear = _context.HalfYears.Find(id);
            if (halfYear == null)
                return NotFound();

            _context.HalfYears.Remove(halfYear);
            _context.SaveChanges();

            return NoContent();
        }


    }
}