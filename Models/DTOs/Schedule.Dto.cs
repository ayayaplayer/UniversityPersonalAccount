namespace UniversityPersonalAccount.Models.DTOs
{
     public class ScheduleDto
    {
        public int Id { get; set; }
        public string? SubjectName { get; set; }
        public string? Classroom { get; set; }

        public List<GroupBaseDto>? Groups { get; set; }
        public List<SessionBaseDto>? Sessions { get; set; }
     }

    
}