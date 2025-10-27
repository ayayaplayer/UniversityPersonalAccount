using UniversityPersonalAccount.Models.DTOs.Base;

namespace UniversityPersonalAccount.Models.DTOs.Group

{
    public class GroupGetAllDto
    {
        public int Id { get; set; }
        public string GroupName { get; set; } = string.Empty;
    }

    public class GroupGetByIdDto
    {
        public int Id { get; set; }
        public string GroupName { get; set; } = string.Empty;
        
    }

    public class GroupCreateDto
    {
        public string GroupName { get; set; } = string.Empty;
        public int CourseId { get; set; }
        public int FacultyId { get; set; }

    }

    public class GroupUpdateDto
    {
        public int Id { get; set; }
        public string GroupName { get; set; } = string.Empty;
        
    }

    public class GroupBasicDto
    {
        public int Id { get; set; }
        public int CourseId;
        public string GroupName { get; set; } = string.Empty;
    }
}