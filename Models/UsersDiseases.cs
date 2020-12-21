using System;
using System.ComponentModel.DataAnnotations;

namespace DrHelperBack.Models
{
    public class UsersDiseases
    {
        [Key]
        public int idUsersDiseases { get; set; }
        [Required]
        public int idUser { get; set; }
        [Required]
        public int idDisease { get; set; }
        [Required]
        public DateTime occurrenceDate { get; set; }        
        [MaxLength(200)]
        public string description { get; set; }
    }
}
