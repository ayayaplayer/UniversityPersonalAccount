using System.ComponentModel.DataAnnotations;

namespace UniversityPersonalAccount.Models.Entities
{


    public class Session
    {
        public int Id { get; set; }
        
        public int DayOfWeek { get; set; }
        public DateTime StartTime { get; set; } = DateTime.Now;
        public DateTime EndTime { get; set; } = DateTime.Now;
       
        public int HalfYearId { get; set; }
        public HalfYear HalfYear { get; set; } = null!;

    }
}
