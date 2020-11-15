using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DrHelperBack.Models
{
    public class Timeblock
    {
        [Key]
        public int id_timeblock { get; set; }
        [Required]
        public DateTime start_time { get; set; }
        [Required]
        public DateTime end_time { get; set; }
        [Required]
        public bool avaliable { get; set; }
        [Required]
        public int id_user { get; set; }
    }
}
