using System.ComponentModel.DataAnnotations;

namespace DrHelperBack.DTOs
{
    public class UsersPrescriptionsCreateDTO
    {
        [Key]
        public int idUser { get; set; }
        [Key]
        public int idPrescription { get; set; }
    }
}
