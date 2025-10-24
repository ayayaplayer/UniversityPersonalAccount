using System.Data;

namespace UniversityPersonalAccount.Models.Entities
{
    public class HalfYear
    {
        public int Id { get; set; }
        public DateOnly DateStart { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public DateOnly DateEnd { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public ICollection<Session> Sessions { get; } = new List<Session>();
    }
}
