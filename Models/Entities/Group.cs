namespace UniversityPersonalAccount.Models.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string GroupName { get; set; } = string.Empty;

        public ICollection<Student> Students { get; } = new List<Student>();
        

        public ICollection<Course> Courses { get; } = new List<Course>();


        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; } = null!;
    }
}
