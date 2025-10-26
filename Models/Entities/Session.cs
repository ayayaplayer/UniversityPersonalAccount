using System.ComponentModel.DataAnnotations;

namespace UniversityPersonalAccount.Models.Entities
{

    public enum ClassNumber
    {
        [Display(Name = "1-я пара")]
        First = 1,
        
        [Display(Name = "2-я пара")]
        Second = 2,
        
        [Display(Name = "3-я пара")]
        Third = 3,
        
        [Display(Name = "4-я пара")]
        Fourth = 4,
        
        [Display(Name = "5-я пара")]
        Fifth = 5,
        
        [Display(Name = "6-я пара")]
        Sixth = 6,
        
        [Display(Name = "7-я пара")]
        Seventh = 7
    }





    public class Session
    {
        public int Id { get; set; }

        public int ClassNumber { get; set; }
        public TimeOnly StartTime { get; set; } = TimeOnly.FromDateTime(DateTime.Now);
        public TimeOnly EndTime { get; set; } = TimeOnly.FromDateTime(DateTime.Now);
        public int HalfYearId { get; set; }
        public HalfYear HalfYear { get; set; } = null!;

    }
}
