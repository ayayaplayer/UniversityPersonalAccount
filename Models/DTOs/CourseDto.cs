namespace UniversityPersonalAccount.Models.DTOs
{
         
   public class CourseGetAllDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? DegreeLevel { get; set; }
    }

    public class CourseGetByIdDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? DegreeLevel { get; set; }
        public List<GroupBasicDto> Groups { get; set; } = new();
        public int StudentCount { get; set; }
    }

    public class CourseCreateDto
    {
        public string? Name { get; set; }
        public string? DegreeLevel { get; set; }
    }

    public class CourseUpdateDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? DegreeLevel { get; set; }
    }

    public class CourseBasicDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}