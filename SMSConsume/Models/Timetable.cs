using System.ComponentModel.DataAnnotations;

namespace SMSConsume.Models
{
    public class Timetable
    {
        [Key]
        public int TimetableID { get; set; }
        public int ClassID { get; set; }
        public string Day { get; set; }
        public int SubjectID { get; set; }
        public int TeacherId { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
    }
}
