namespace UniversityPersonalAccount.Models.DTOs
{
    public class SessionDto : SessionBaseDto
    {

       
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }

        public int HalfYearId { get; set; }
        public int ScheduleId { get; set; }
    }

    public class SessionBaseDto
    {
        public int Id { get; set; }
        public string ClassNumber { get; set; } = string.Empty;
    }
}