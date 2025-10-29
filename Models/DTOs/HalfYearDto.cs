namespace UniversityPersonalAccount.Models.DTOs
{
    public class HalfYearDto
    {
        public int Id { get; set; }
        public DateOnly DateStart { get; set; }
        public DateOnly DateEnd { get; set; }

        public int HalfYearId { get; set; }
        public List<SessionBaseDto>? Sessions { get; set; }
    }
}