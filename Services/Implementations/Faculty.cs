using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UniversityPersonalAccount.Data;
using UniversityPersonalAccount.Models.DTOs;
using UniversityPersonalAccount.Models.Entities;
using UniversityPersonalAccount.Services.Interfaces;

namespace UniversityPersonalAccount.Services
{
    public class FacultyService : BaseCrudService<Faculty, FacultyDto>, IFacultyService
    {
        public FacultyService(PersonalAccountDbContext context, IMapper mapper, ILogger<FacultyService> logger)
            : base(context, mapper, logger)
        {
        }

        public override IEnumerable<FacultyDto> GetAll()
        {
            _logger.LogInformation("Получение всех факультетов с группами");
            var faculties = _context.Faculties
                .Include(f => f.Groups)
                .ThenInclude(g => g.Students)
                .ToList();

            return _mapper.Map<IEnumerable<FacultyDto>>(faculties);
        }

        public override FacultyDto? GetById(int id)
        {
            var faculty = _context.Faculties
                .Include(f => f.Groups)
                .ThenInclude(g => g.Students)
                .FirstOrDefault(f => f.Id == id);

            if (faculty == null)
            {
                _logger.LogWarning("Факультет с Id={Id} не найден", id);
                return null;
            }

            return _mapper.Map<FacultyDto>(faculty);
        }
    }
}
