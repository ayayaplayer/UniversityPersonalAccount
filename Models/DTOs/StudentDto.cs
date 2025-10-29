namespace UniversityPersonalAccount.Models.DTOs
{
    public class StudentDto : StudentBaseDto
    {
        public string Email { get; set; } = string.Empty;

        public int GroupId { get; set; }
    }

    public class StudentBaseDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
    }
}