using System.Text.RegularExpressions;

namespace UniversityPersonalAccount.Models.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string Email { get; set; } = string.Empty;
        public int GroupId { get; set; }
        public Group? group { get; set; }
    }
}
