using System.ComponentModel.DataAnnotations;

namespace DrHelperBack.Models
{
    public class UsersPrescriptions
    {
        [Key]
        public int idUser { get; set; }
        [Key]
        public int idPrescription { get; set; }
    }
}
