using System.ComponentModel.DataAnnotations;

namespace SMSConsume.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Urole { get; set; }
        public string? Email { get; set; }
        public double Phone { get; set; }
    }
}
