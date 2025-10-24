namespace UniversityPersonalAccount.Models.DTOs

{
 public class SessionDto
    {
        public int Id { get; set; }
        public int DayOfWeek { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public HalfYearDto? HalfYear { get; set; }
    }

    public class SessionCreateDto
    {
        public int DayOfWeek { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public int HalfYearId { get; set; }
    }

    public class SessionUpdateDto
    {
        public int Id { get; set; }
        public int DayOfWeek { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }
}