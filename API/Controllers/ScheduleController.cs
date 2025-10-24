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
    public class ScheduleController : ControllerBase
    {
        private readonly PersonalAccountDbContext _context;
        private readonly IMapper _mapper;

        public ScheduleController(PersonalAccountDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        [HttpGet("{id}")]
        public IActionResult GetScheduleById(int id)
        {
            var schedule = _context.Schedules.Find(id);
            if (schedule == null)
                return NotFound();

            var scheduleDto = _mapper.Map<ScheduleDto>(schedule);
            return Ok(scheduleDto);
        }



        [HttpGet]
        public IActionResult GetAllSchedules()
        {
            var schedules = _context.Schedules.ToList();
            var schedulesDtos = _mapper.Map<List<ScheduleDto>>(schedules);
            return Ok(schedulesDtos);


        }


        [HttpPost]
        public IActionResult CreateSchedule(ScheduleCreateDto dto)
        {
            var schedule = _mapper.Map<Schedule>(dto);
            _context.Schedules.Add(schedule);
            _context.SaveChanges();

            var scheduleDto = _mapper.Map<ScheduleDto>(schedule);
            return CreatedAtAction(nameof(GetScheduleById), new { id = schedule.Id }, scheduleDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSchedule(int id, ScheduleUpdateDto dto)
        {
            var schedule = _context.Schedules.Find(id);
            if (schedule == null)
                return NotFound();

            _mapper.Map(dto, schedule);
            _context.SaveChanges();

            return Ok(_mapper.Map<ScheduleDto>(schedule));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSchedule(int id)
        {
            var schedule = _context.Schedules.Find(id);
            if (schedule == null)
                return NotFound();

            _context.Schedules.Remove(schedule);
            _context.SaveChanges();

            return NoContent();
        }


    }
}