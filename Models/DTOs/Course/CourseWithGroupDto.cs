using UniversityPersonalAccount.Models.DTOs.Group;
using UniversityPersonalAccount.Models.Entities;


namespace UniversityPersonalAccount.Models.DTOs.Course
{
    
        public class CourseWithGroupGetAllDto
        {
            public int Id { get; set; }
            public CourseName CourseName { get; set; }
            public DegreeLevel DegreeLevel { get; set; }

            public GroupBasicDto? Group { get; set; }
            public string? GroupName     { get; set; }

        }

        public class CourseWithGroupGetByIdDto
        {
            public int Id { get; set; }
            public CourseName CourseName { get; set; }
            public DegreeLevel DegreeLevel { get; set; }
            public string? GroupName { get; set; }

        }

    
}

