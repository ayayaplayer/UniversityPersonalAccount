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
    public class SessionsController : ControllerBase
    {
        private readonly PersonalAccountDbContext _context;
        private readonly IMapper _mapper;

        public SessionsController(PersonalAccountDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        [HttpGet("{id}")]
        public IActionResult GetSessionById(int id)
        {
            var session = _context.Sessions.Find(id);
            if (session == null)
                return NotFound();

            var sessionDto = _mapper.Map<SessionDto>(session);
            return Ok(sessionDto);
        }



        [HttpGet]
        public IActionResult GetAllSessions()
        {
            var sessions = _context.Sessions.ToList();
            var sessionsDtos = _mapper.Map<List<SessionDto>>(sessions);
            return Ok(sessionsDtos);


        }


        [HttpPost]
        public IActionResult CreateSession(SessionCreateDto dto)
        {
            var session = _mapper.Map<Session>(dto);
            _context.Sessions.Add(session);
            _context.SaveChanges();

            var sessionDto = _mapper.Map<SessionDto>(session);
            return CreatedAtAction(nameof(GetSessionById), new { id = session.Id }, sessionDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSession(int id, SessionUpdateDto dto)
        {
            var session = _context.Sessions.Find(id);
            if (session == null)
                return NotFound();

            _mapper.Map(dto, session);
            _context.SaveChanges();

            return Ok(_mapper.Map<SessionDto>(session));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSession(int id)
        {
            var session = _context.Sessions.Find(id);
            if (session == null)
                return NotFound();

            _context.Sessions.Remove(session);
            _context.SaveChanges();

            return NoContent();
        }


    }
}