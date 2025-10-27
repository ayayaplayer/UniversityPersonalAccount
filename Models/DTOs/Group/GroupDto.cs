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
     
    }

    public class GroupUpdateDto
    {
        public int Id { get; set; }
        public string GroupName { get; set; } = string.Empty;
        
    }

    public class GroupBasicDto
    {
        public int Id { get; set; }
        public string GroupName { get; set; } = string.Empty;
    }
}