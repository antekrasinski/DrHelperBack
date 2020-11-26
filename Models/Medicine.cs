using System.ComponentModel.DataAnnotations;

namespace DrHelperBack.Models
{
    public class Medicine
    {
        [Key]
        public int idMedicine { get; set; }
        [Required]
        [MaxLength(100)]
        public string name { get; set; }
    }
}
