using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DrHelperBack.DTOs
{
    public class UsersDiseasesCreateDTO
    {
        [Required]
        public int idUser { get; set; }
        [Required]
        public int idDisease { get; set; }
        [Required]
        public string occurrenceDate { get; set; }
        [MaxLength(200)]
        public string description { get; set; }
    }
}
