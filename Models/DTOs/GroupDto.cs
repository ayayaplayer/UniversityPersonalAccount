namespace UniversityPersonalAccount.Models.DTOs
{
     public class GroupDto : GroupBaseDto
    {
        public int FacultyId { get; set; }
        public int CourseId { get; set; }

        
        public List<StudentBaseDto>? Students { get; set; }
    }

    
    public class GroupBaseDto
    {
        public int Id { get; set; }
        public string GroupName { get; set; } = string.Empty;
    }
}