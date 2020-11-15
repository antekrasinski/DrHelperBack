using System.ComponentModel.DataAnnotations;

namespace DrHelperBack.Models
{
    public class Disease
    {
        [Key]
        public int id_disease { get; set; }
        [Required]
        [MaxLength(100)]
        public string name { get; set; }
    }
}
