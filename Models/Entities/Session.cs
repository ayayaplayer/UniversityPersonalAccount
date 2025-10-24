using System.ComponentModel.DataAnnotations;

namespace UniversityPersonalAccount.Models.Entities
{


    public class Session
    {
        public int Id { get; set; }
        
        public int DayOfWeek { get; set; }
        public TimeOnly StartTime { get; set; } = new TimeOnly();
        public TimeOnly EndTime { get; set; } = new TimeOnly();
        public int HalfYearId { get; set; }
        public HalfYear HalfYear { get; set; } = null!;

    }
}
