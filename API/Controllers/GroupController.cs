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
    public class GroupController : ControllerBase
    {
        private readonly PersonalAccountDbContext _context;
        private readonly IMapper _mapper;

        public GroupController(PersonalAccountDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        [HttpGet("{id}")]
        public IActionResult GetGroupById(int id)
        {
            var group = _context.Groups.Find(id);
            if (group == null)
                return NotFound();

            var groupDto = _mapper.Map<GroupDto>(group);
            return Ok(groupDto);
        }



        [HttpGet]
        public IActionResult GetAllGroups()
        {
            var groups = _context.Groups.ToList();
            var groupsDtos = _mapper.Map<List<GroupDto>>(groups);
            return Ok(groupsDtos);


        }


        [HttpPost]
        public IActionResult CreateGroup(GroupCreateDto dto)
        {
            var group = _mapper.Map<Group>(dto);
            _context.Groups.Add(group);
            _context.SaveChanges();

            var groupDto = _mapper.Map<GroupDto>(group);
            return CreatedAtAction(nameof(GetGroupById), new { id = group.Id }, groupDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGroup(int id, GroupUpdateDto dto)
        {
            var group = _context.Groups.Find(id);
            if (group == null)
                return NotFound();

            _mapper.Map(dto, group);
            _context.SaveChanges();

            return Ok(_mapper.Map<StudentDto>(group));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGroup(int id)
        {
            var group = _context.Groups.Find(id);
            if (group == null)
                return NotFound();

            _context.Groups.Remove(group);
            _context.SaveChanges();

            return NoContent();
        }


    }
}