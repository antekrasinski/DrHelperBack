using System.ComponentModel.DataAnnotations;

namespace DrHelperBack.Models
{
    public class PerscriptionsMedicine
    {
        [Key]
        public int idPerscription { get; set; }
        [Key]
        public int idMedicine { get; set; }
        [MaxLength(100)]
        public string amount { get; set; }
    }
}
