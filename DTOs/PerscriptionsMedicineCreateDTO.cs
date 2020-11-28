using System.ComponentModel.DataAnnotations;

namespace DrHelperBack.DTOs
{
    public class PerscriptionsMedicineCreateDTO
    {
        [Key]
        public int idPerscription { get; set; }
        [Key]
        public int idMedicine { get; set; }
        [MaxLength(100)]
        public string amount { get; set; }
    }
}
