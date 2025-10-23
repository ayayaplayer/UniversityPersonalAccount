namespace UniversityPersonalAccount.Models.DTOs
{

    public class StudentDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string Email { get; set; } = string.Empty;
        public GroupDto? Group { get; set; }
        public ICollection<CourseDto> Courses { get; set; } = new List<CourseDto>();
    }
    public class StudentCreateDto
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string Email { get; set; } = string.Empty;
    }

    public class StudentUpdateDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string Email { get; set; } = string.Empty;
    }

}