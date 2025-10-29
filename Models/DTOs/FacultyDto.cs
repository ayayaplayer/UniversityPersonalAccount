namespace UniversityPersonalAccount.Models.DTOs
{
     public class FacultyDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<GroupBaseDto>? Groups { get; set; }
    }
}