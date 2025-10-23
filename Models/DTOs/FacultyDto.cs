namespace UniversityPersonalAccount.Models.DTOs
{
    
     public class FacultyDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<GroupDto> Groups { get; set; } = new List<GroupDto>();
    }

    public class FacultyCreateDto
    {
        public string? Name { get; set; }
    }

    public class FacultyUpdateDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}