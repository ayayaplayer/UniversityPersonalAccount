namespace UniversityPersonalAccount.Models.DTOs
{

    public class ScheduleGetAllDto
    {
        public int Id { get; set; }
        public string? SubjectName { get; set; }
        public string? Classroom { get; set; }
    }

    public class ScheduleGetByIdDto
    {
        public int Id { get; set; }
        public string? SubjectName { get; set; }
        public string? Classroom { get; set; }
        public List<GroupBasicDto> Groups { get; set; } = new();
        public List<SessionBasicDto> Sessions { get; set; } = new();
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