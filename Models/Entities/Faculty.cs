namespace UniversityPersonalAccount.Models.Entities
{
    public class Faculty
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Group> Groups { get; set; } = new List<Group>();

    }
}
