namespace UniversityPersonalAccount.Models.DTOs
{
    public class SessionDto
    {
        public int Id { get; set; }
        public string ClassNumber { get; set; } = string.Empty;
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }

        public int HalfYearId { get; set; }
    }

    public class SessionShortDto
    {
        public int Id { get; set; }
        public string ClassNumber { get; set; } = string.Empty;
    }
}