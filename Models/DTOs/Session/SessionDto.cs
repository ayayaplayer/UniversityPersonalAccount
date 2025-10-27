using UniversityPersonalAccount.Models.Entities;

namespace UniversityPersonalAccount.Models.DTOs.Session

{
    public class SessionGetAllDto
    {
        public int Id { get; set; }
        public ClassNumber ClassNumber { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }

    public class SessionGetByIdDto
    {
        public int Id { get; set; }
        public ClassNumber ClassNumber { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }

    public class SessionCreateDto
    {
        public ClassNumber ClassNumber { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
      
    }

    public class SessionUpdateDto
    {
        public int Id { get; set; }
        public ClassNumber ClassNumber { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }

    public class SessionBasicDto
    {
        public int Id { get; set; }
        public ClassNumber ClassNumber { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }
}