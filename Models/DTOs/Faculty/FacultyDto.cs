namespace UniversityPersonalAccount.Models.DTOs.Faculty
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
      
    }

    public class FacultyCreateDto
    {
        public string? Name { get; set; }
        public int  GroupId { get; set; }
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