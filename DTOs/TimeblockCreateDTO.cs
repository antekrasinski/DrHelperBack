using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DrHelperBack.DTOs
{
    public class TimeblockCreateDTO
    {
        [Required]
        public string startTime { get; set; }
        [Required]
        public string endTime { get; set; }
        [Required]
        public bool avaliable { get; set; }
        [Required]
        public int idUser { get; set; }
    }
}
