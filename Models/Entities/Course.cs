using System.ComponentModel.DataAnnotations;

namespace UniversityPersonalAccount.Models.Entities
{
    public class Course
    { 
        public int Id { get; set; }
        [Range (1,7)]
        public string? Name { get; set; }
        public string? Degree { get; set; }

        public ICollection<Group> Groups { get; set; } = new List<Group>();
        public ICollection<Student> Students { get; set; } = new List<Student>();

    }
}
