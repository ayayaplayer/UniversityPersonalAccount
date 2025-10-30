


namespace UniversityPersonalAccount.Models.DTOs
{
    public class GroupDto
    {
        public int Id { get; set; }
        public string GroupName { get; set; } = string.Empty;

        public int CourseId { get; set; }
        public int FacultyId { get; set; }

        public List<StudentDto> Students { get; set; } = new();
    }
}