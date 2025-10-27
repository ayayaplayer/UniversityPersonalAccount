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