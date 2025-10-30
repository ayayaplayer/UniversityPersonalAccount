using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UniversityPersonalAccount.Data;
using UniversityPersonalAccount.Models.DTOs;
using UniversityPersonalAccount.Models.Entities;
using UniversityPersonalAccount.Services.Interfaces;

namespace UniversityPersonalAccount.Services
{
    public class ScheduleService : BaseCrudService<Schedule, ScheduleDto>, IScheduleService
    {
        public ScheduleService(PersonalAccountDbContext context, IMapper mapper, ILogger<ScheduleService> logger)
            : base(context, mapper, logger)
        {
        }

        public override IEnumerable<ScheduleDto> GetAll()
        {
            var list = _context.Schedules
                .Include(s => s.Groups)
                .Include(s => s.Sessions)
                .ToList();
            return _mapper.Map<IEnumerable<ScheduleDto>>(list);
        }

        public override ScheduleDto? GetById(int id)
        {
            var entity = _context.Schedules
                .Include(s => s.Groups)
                .Include(s => s.Sessions)
                .FirstOrDefault(s => s.Id == id);
            return _mapper.Map<ScheduleDto?>(entity);
        }
    }
}
