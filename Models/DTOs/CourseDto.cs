using UniversityPersonalAccount.Models.Entities;

namespace UniversityPersonalAccount.Models.DTOs
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public int DegreeLevel { get; set; }

        
        public List<GroupShortDto>? Groups { get; set; }
        public List<StudentShortDto>? Students { get; set; }
    }
}