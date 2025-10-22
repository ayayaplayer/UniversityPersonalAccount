namespace UniversityPersonalAccount.Models.Entities
{
    public class HalfYear
    {
        public int Id { get; set; }
        DateOnly DateStart { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        DateOnly DateEnd { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public int SessionId { get; set; }
        public Session Session { get; set; } = null!;
    }
}
