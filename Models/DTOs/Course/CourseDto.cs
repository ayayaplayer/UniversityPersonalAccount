using UniversityPersonalAccount.Models.Entities;
namespace UniversityPersonalAccount.Models.DTOs.Course
{
         
   public class CourseGetAllDto
    {
        public int Id { get; set; }
        public CourseName CourseName { get; set; }
        public DegreeLevel DegreeLevel { get; set; }
    }

    public class CourseGetByIdDto
    {
        public int Id { get; set; }
        public CourseName CourseName { get; set; }
        public DegreeLevel DegreeLevel { get; set; }

    }

    public class CourseCreateDto
    {
        public CourseName CourseName { get; set; }
        public DegreeLevel DegreeLevel { get; set; }
    }

    public class CourseUpdateDto
    {
        public int Id { get; set; }
        public CourseName CourseName { get; set; }
        public DegreeLevel DegreeLevel { get; set; }
    }

    public class CourseBasicDto
    {
        public int Id { get; set; }
        public CourseName CourseName { get; set; }
        
    }
}