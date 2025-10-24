using System.Data;

namespace UniversityPersonalAccount.Models.Entities
{
    public class HalfYear
    {
        public int Id { get; set; }
        public DateOnly DateStart { get; set; } = new DateOnly();
        public DateOnly DateEnd { get; set; } = new DateOnly();
        public ICollection<Session> Sessions { get; } = new List<Session>();
    }
}
