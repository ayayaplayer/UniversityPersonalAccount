using AutoMapper;
using Microsoft.Extensions.Logging;
using UniversityPersonalAccount.Data;
using UniversityPersonalAccount.Models.DTOs;
using UniversityPersonalAccount.Models.Entities;
using UniversityPersonalAccount.Services.Interfaces;

namespace UniversityPersonalAccount.Services
{
    public class StudentService : BaseCrudService<Student, StudentDto>, IStudentService
    {
        public StudentService(PersonalAccountDbContext context, IMapper mapper, ILogger<StudentService> logger)
            : base(context, mapper, logger)
        {
        }
    }
}
