namespace UniversityPersonalAccount.Models.DTOs
{
     public class FacultyDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<GroupShortDto>? Groups { get; set; }
    }
}