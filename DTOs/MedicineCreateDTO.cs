using System.ComponentModel.DataAnnotations;

namespace DrHelperBack.DTOs
{
    public class MedicineCreateDTO
    {
        [Required]
        [MaxLength(100)]
        public string name { get; set; }
    }
}
