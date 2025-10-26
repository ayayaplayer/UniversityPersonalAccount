namespace UniversityPersonalAccount.Models.DTOs

{
 public class SessionGetAllDto
    {
        public int Id { get; set; }
        public int DayOfWeek { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }

    public class SessionGetByIdDto
    {
        public int Id { get; set; }
        public int DayOfWeek { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public HalfYearBasicDto? HalfYear { get; set; }
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
        public int HalfYearId { get; set; }
    }

    public class SessionBasicDto
    {
        public int Id { get; set; }
        public int DayOfWeek { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }
}