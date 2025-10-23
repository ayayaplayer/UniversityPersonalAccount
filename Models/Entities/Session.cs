using System.ComponentModel.DataAnnotations;

namespace UniversityPersonalAccount.Models.Entities
{


    public class Session
    {
        public int Id { get; set; }
        
        public int DayOfWeek { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public int HalfYearId { get; set; }
        public HalfYear HalfYear { get; set; } = null!;

    }
}
