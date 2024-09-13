using System.ComponentModel.DataAnnotations;

namespace SMSConsume.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DOB { get; set; }
        public string Gender { get; set; }
        public string Class { get; set; }
        public string Section { get; set; }
        public int? ParentID { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public string Status { get; set; } = "Active";
    }
}
