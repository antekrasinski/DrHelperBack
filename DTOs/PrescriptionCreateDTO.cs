using System.ComponentModel.DataAnnotations;

namespace DrHelperBack.DTOs
{
    public class PrescriptionCreateDTO
    {
        [Required]
        public string prescriptionDate { get; set; }
    }
}
