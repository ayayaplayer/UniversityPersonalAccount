using System.Data;

namespace UniversityPersonalAccount.Models.Entities
{
    public class HalfYear
    {
        public int Id { get; set; }
        public DateTime DateStart { get; set; } = DateTime.Now;
        public DateTime DateEnd { get; set; } = DateTime.Now;
        public ICollection<Session> Sessions { get; } = new List<Session>();
    }
}
