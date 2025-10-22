namespace UniversityPersonalAccount.Models.Entities
{
    public class Course
    { 
        public int Id { get; set; }
        public int Name { get; set; }
        public string? Degree { get; set; }
        public int GroupId { get; set; }
        public Group? group { get; set; }
    }
}
