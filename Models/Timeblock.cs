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
        public int idTimeblock { get; set; }
        [Required]
        public DateTime startTime { get; set; }
        [Required]
        public DateTime endTime { get; set; }
        [Required]
        public bool avaliable { get; set; }
        [Required]
        public int idUser { get; set; }
        public int idAppointment { get; set; }
    }
}
