using System.ComponentModel.DataAnnotations;

namespace UniversityPersonalAccount.Models.Entities
{
    public enum CourseName
    {
        [Display(Name = "Первый")]
        First = 1,

        [Display(Name = "Второй")]
        Second = 2,

        [Display(Name = "Третий")]
        Third = 3,

        [Display(Name = "Четвертый")]
        Fourth = 4,   
    }

    public enum DegreeLevel
    {
        [Display(Name = "Бакалавриат")]
        First = 1,

        [Display(Name = "Магистратура")]
        Second = 2,

        [Display(Name = "Аспирантура")]
        Third = 3,     
    }

    public class Course
    { 
        public int Id { get; set; }

        public CourseName CourseName { get; set; }        
        public int DegreeLevel { get; set; } 

        public ICollection<Group> Groups { get; set; } = new List<Group>();
        public ICollection<Student> Students { get; set; } = new List<Student>();

    }
}
