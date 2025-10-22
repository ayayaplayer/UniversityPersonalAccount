namespace UniversityPersonalAccount.Models.Entities
{
    public class Faculty
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int GroupId { get; set; }
        public Group? group { get; set; }
    }
}
