using AutoMapper;
using Microsoft.Extensions.Logging;
using UniversityPersonalAccount.Data;
using UniversityPersonalAccount.Models.DTOs;
using UniversityPersonalAccount.Models.Entities;
using UniversityPersonalAccount.Services.Interfaces;

namespace UniversityPersonalAccount.Services
{
    public class SessionService : BaseCrudService<Session, SessionDto>, ISessionService
    {
        public SessionService(PersonalAccountDbContext context, IMapper mapper, ILogger<SessionService> logger)
            : base(context, mapper, logger)
        {
        }
    }
}
