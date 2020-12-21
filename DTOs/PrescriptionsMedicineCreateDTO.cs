using System.ComponentModel.DataAnnotations;

namespace DrHelperBack.DTOs
{
    public class PrescriptionsMedicineCreateDTO
    {
        [Key]
        public int idPrescription { get; set; }
        [Key]
        public int idMedicine { get; set; }
        [MaxLength(100)]
        public string amount { get; set; }
    }
}
