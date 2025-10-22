namespace UniversityPersonalAccount.Models.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string GroupName { get; set; } = string.Empty;

        public ICollection<Student> students { get; } = new List<Student>();
        public ICollection<Faculty> faculties { get; } = new List<Faculty>();

        public ICollection<Course> courses { get; } = new List<Course>();


        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; } = null!;
    }
}
