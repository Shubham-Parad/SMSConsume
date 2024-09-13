using System.ComponentModel.DataAnnotations;

namespace SMSConsume.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Qualification { get; set; }
        public string SubjectSpecialization { get; set; }
        public string ContactNumber { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public string Status { get; set; } = "Active";
    }
}
