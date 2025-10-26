namespace UniversityPersonalAccount.Models.DTOs

{
    public class GroupGetAllDto
    {
        public int Id { get; set; }
        public string GroupName { get; set; } = string.Empty;
        public FacultyBasicDto? Faculty { get; set; }
    }

    public class GroupGetByIdDto
    {
        public int Id { get; set; }
        public string GroupName { get; set; } = string.Empty;
        public FacultyBasicDto? Faculty { get; set; }
        public List<StudentBasicDto> Students { get; set; } = new();
        public List<CourseBasicDto> Courses { get; set; } = new();
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
        public int FacultyId { get; set; }
    }

    public class GroupBasicDto
    {
        public int Id { get; set; }
        public string GroupName { get; set; } = string.Empty;
    }
}