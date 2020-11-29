using System.ComponentModel.DataAnnotations;

namespace DrHelperBack.Models
{
    public class UsersAppointments
    {
        [Key]
        public int idUser { get; set; }
        [Key]
        public int idAppointment { get; set; }

    }
}
