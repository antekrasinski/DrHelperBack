using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DrHelperBack.DTOs
{
    public class AppointmentCreateDTO
    {
        [MaxLength(200)]
        public string description { get; set; }
        [Required]
        public int idTimeblock { get; set; }
    }
}
