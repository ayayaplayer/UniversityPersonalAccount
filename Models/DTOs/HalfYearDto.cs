namespace UniversityPersonalAccount.Models.DTOs
{ 
  public class HalfYearGetAllDto
    {
        public int Id { get; set; }
        public DateOnly DateStart { get; set; }
        public DateOnly DateEnd { get; set; }
    }

    public class HalfYearGetByIdDto
    {
        public int Id { get; set; }
        public DateOnly DateStart { get; set; }
        public DateOnly DateEnd { get; set; }
      
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

    public class HalfYearBasicDto
    {
        public int Id { get; set; }
        public DateOnly DateStart { get; set; }
        public DateOnly DateEnd { get; set; }
    }
 }   