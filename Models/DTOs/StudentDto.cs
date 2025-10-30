namespace UniversityPersonalAccount.Models.DTOs
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string Email { get; set; } = string.Empty;
        public int GroupId { get; set; }
    }
   
}