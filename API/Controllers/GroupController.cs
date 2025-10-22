using Microsoft.AspNetCore.Mvc;
using UniversityPersonalAccount.Data;
using UniversityPersonalAccount.Models.Entities;

namespace UniversityPersonalAccount.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly PersonalAccountDbContext _dbContext;

        public GroupController(PersonalAccountDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        [Route("[controller]")]
        public ActionResult<IEnumerable<Group>> GetGroup()
        {
            var group = _dbContext.Groups;
            return Ok(group);
        }

    }
}