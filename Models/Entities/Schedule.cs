namespace UniversityPersonalAccount.Models.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        public string? SubjectName { get; set; }
        public string? Classroom { get; set; }
        public ICollection<Group> Groups { get; set; } = new List<Group>();

        public int SessionId { get; set; }
        public ICollection<Session> Sessions { get; set; } = new List<Session>();
    }
}
