namespace UniversityPersonalAccount.Models.DTOs
{ 
 public class HalfYearDto
    {
        public int Id { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public ICollection<SessionDto> Sessions { get; set; } = new List<SessionDto>();
    }

    public class HalfYearCreateDto
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }

    public class HalfYearUpdateDto
    {
        public int Id { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }
 }   