namespace UniversityPersonalAccount.Models.DTOs
{
    
     public class FacultyGetAllDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    public class FacultyGetByIdDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<GroupBasicDto> Groups { get; set; } = new();
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

    public class FacultyBasicDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}