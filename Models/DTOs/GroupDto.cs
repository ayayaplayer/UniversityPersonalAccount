namespace UniversityPersonalAccount.Models.DTOs
{
     public class GroupDto
    {
        public int Id { get; set; }
        public string GroupName { get; set; } = string.Empty;

        public int FacultyId { get; set; }
        public int CourseId { get; set; }

        
        public List<StudentShortDto>? Students { get; set; }
    }

    
    public class GroupShortDto
    {
        public int Id { get; set; }
        public string GroupName { get; set; } = string.Empty;
    }
}