namespace UniversityPersonalAccount.Models.DTOs

{
 public class GroupDto
    {
        public int Id { get; set; }
        public string GroupName { get; set; } = string.Empty;
        public FacultyDto? Faculty { get; set; }
        public ICollection<StudentDto> Students { get; set; } = new List<StudentDto>();
        public ICollection<CourseDto> Courses { get; set; } = new List<CourseDto>();
    }

    public class GroupCreateDto
    {
        public string GroupName { get; set; } = string.Empty;

        public int FacultyId { get; set; }
    }

    public class GroupUpdateDto
    {
        public int Id { get; set; }
        public string GroupName { get; set; } = string.Empty;
    }
}