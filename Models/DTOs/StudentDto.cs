namespace UniversityPersonalAccount.Models.DTOs
{

    public class StudentDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string Email { get; set; } = string.Empty;

        public ICollection<GroupDto> Groups { get; set; } = new List<GroupDto>();
        public ICollection<CourseDto> Courses { get; set; } = new List<CourseDto>();
    }
    public class StudentCreateDto
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string Email { get; set; } = string.Empty;

        public int GroupId { get; set; }
    }

    public class StudentUpdateDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string Email { get; set; } = string.Empty;
    }

}