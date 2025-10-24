namespace UniversityPersonalAccount.Models.DTOs
{
          public class CourseDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? DegreeLevel { get; set; }
        public ICollection<GroupDto> Groups { get; set; } = new List<GroupDto>();
        public ICollection<StudentDto> Students { get; set; } = new List<StudentDto>();
    }

    public class CourseCreateDto
    {
        public string? Name { get; set; }
        public string? DegreeLevel { get; set; }
    }

    public class CourseUpdateDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? DegreeLevel { get; set; }
    }
}