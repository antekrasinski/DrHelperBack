using System;
using System.ComponentModel.DataAnnotations;

namespace DrHelperBack.Models
{
    public class Perscription
    {
        [Key]
        public int idPerscription { get; set; }
        [Required]
        public DateTime perscriptionDate { get; set; }
    }
}
