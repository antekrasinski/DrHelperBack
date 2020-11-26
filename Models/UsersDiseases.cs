using System;
using System.ComponentModel.DataAnnotations;

namespace DrHelperBack.Models
{
    public class UsersDiseases
    {
        [Key]
        public int idUser { get; set; }
        [Key]
        public int idDisease { get; set; }
        public DateTime occurrenceDate { get; set; }        
        [MaxLength(200)]
        public string description { get; set; }
    }
}
