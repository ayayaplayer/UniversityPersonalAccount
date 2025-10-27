namespace UniversityPersonalAccount.Models.DTOs
{

  public class StudentGetAllDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string Email { get; set; } = string.Empty;
    }

    public class StudentGetByIdDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string Email { get; set; } = string.Empty;
        
    }

    public class StudentCreateDto
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string Email { get; set; } = string.Empty;
        public int GroupId { get; set; }
    }

    public class StudentUpdateDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string Email { get; set; } = string.Empty;
        public int GroupId { get; set; }
    }

    public class StudentBasicDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string Email { get; set; } = string.Empty;
    }

}