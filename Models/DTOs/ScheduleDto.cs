namespace UniversityPersonalAccount.Models.DTOs
{

    public class ScheduleDto
    {
        public int Id { get; set; }
        public string? SubjectName { get; set; }
        public string? Classroom { get; set; }
        public ICollection<GroupDto> Groups { get; set; } = new List<GroupDto>();
        public ICollection<SessionDto> Sessions { get; set; } = new List<SessionDto>();
    }

    public class ScheduleCreateDto
    {
        public string? SubjectName { get; set; }
        public string? Classroom { get; set; }
    }

    public class ScheduleUpdateDto
    {
        public int Id { get; set; }
        public string? SubjectName { get; set; }
        public string? Classroom { get; set; }
    }

}