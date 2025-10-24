namespace UniversityPersonalAccount.Models.DTOs
{ 
 public class HalfYearDto
    {
        public int Id { get; set; }
        public DateOnly DateStart { get; set; }
        public DateOnly DateEnd { get; set; }
        public ICollection<SessionDto> Sessions { get; set; } = new List<SessionDto>();
    }

    public class HalfYearCreateDto
    {
        public DateOnly DateStart { get; set; }
        public DateOnly DateEnd { get; set; }
    }

    public class HalfYearUpdateDto
    {
        public int Id { get; set; }
        public DateOnly DateStart { get; set; }
        public DateOnly DateEnd { get; set; }
    }
 }   