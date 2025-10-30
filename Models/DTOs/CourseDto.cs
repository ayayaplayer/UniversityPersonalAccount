using UniversityPersonalAccount.Models.Entities;

namespace UniversityPersonalAccount.Models.DTOs
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public int DegreeLevel { get; set; }

        public List<GroupDto> Groups { get; set; } = new();
        public List<StudentDto> Students { get; set; } = new();
    }
}