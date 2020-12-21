using System.ComponentModel.DataAnnotations;

namespace DrHelperBack.Models
{
    public class PrescriptionsMedicine
    {
        [Key]
        public int idPrescription { get; set; }
        [Key]
        public int idMedicine { get; set; }
        [MaxLength(100)]
        public string amount { get; set; }
    }
}
