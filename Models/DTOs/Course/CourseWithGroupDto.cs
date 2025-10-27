using UniversityPersonalAccount.Models.DTOs.Group;

namespace UniversityPersonalAccount.Models.DTOs.Course
{
    
        public class CourseWithGroupGetAllDto
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? DegreeLevel { get; set; }

            public int? GroupId { get; set; }

            public List<GroupBasicDto> Groups { get; set; } = new();
        }

        public class CourseWithGroupGetByIdDto
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? DegreeLevel { get; set; }
            public int? GroupId { get; set; }

        }

    
}

