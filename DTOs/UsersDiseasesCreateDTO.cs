using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DrHelperBack.DTOs
{
    public class UsersDiseasesCreateDTO
    {
        [Key]
        public int idUser { get; set; }
        [Key]
        public int idDisease { get; set; }
        public string occurrenceDate { get; set; }
        [MaxLength(200)]
        public string description { get; set; }
    }
}
