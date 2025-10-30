using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UniversityPersonalAccount.Data;
using UniversityPersonalAccount.Models.DTOs;
using UniversityPersonalAccount.Models.Entities;
using UniversityPersonalAccount.Services.Interfaces;

namespace UniversityPersonalAccount.Services
{
    public class HalfYearService : BaseCrudService<HalfYear, HalfYearDto>, IHalfYearService
    {
        public HalfYearService(PersonalAccountDbContext context, IMapper mapper, ILogger<HalfYearService> logger)
            : base(context, mapper, logger)
        {
        }

        public override IEnumerable<HalfYearDto> GetAll()
        {
            var list = _context.HalfYears.Include(h => h.Sessions).ToList();
            return _mapper.Map<IEnumerable<HalfYearDto>>(list);
        }

        public override HalfYearDto? GetById(int id)
        {
            var entity = _context.HalfYears
                .Include(h => h.Sessions)
                .FirstOrDefault(h => h.Id == id);
            return _mapper.Map<HalfYearDto?>(entity);
        }
    }
}
