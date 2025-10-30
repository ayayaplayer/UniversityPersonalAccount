namespace UniversityPersonalAccount.Models.DTOs
{
    public class ScheduleDto
    {
        public int Id { get; set; }
        public string? SubjectName { get; set; }
        public string? Classroom { get; set; }

        public List<int> GroupIds { get; set; } = new();
        public List<int> SessionIds { get; set; } = new();

    }

    

}