namespace UniversityPersonalAccount.Models.Entities
{
    public class HalfYear
    {
        public int Id { get; set; }
        DateOnly DateStart { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        DateOnly DateEnd { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public ICollection<Session> Sessions { get; } = new List<Session>();
    }
}
