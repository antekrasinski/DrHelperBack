using System.ComponentModel.DataAnnotations;

namespace DrHelperBack.Models
{
    public class Appointment
    {
        [Key]
        public int idAppointment { get; set; }
        [MaxLength(200)]
        public string description { get; set; }
        [Required]
        public int idTimeblock { get; set; }
    }
}
