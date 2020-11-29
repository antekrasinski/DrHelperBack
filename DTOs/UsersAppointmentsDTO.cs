using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DrHelperBack.DTOs
{
    public class UsersAppointmentsDTO
    {
        [Key]
        public int idUser { get; set; }
        [Key]
        public int idAppointment { get; set; }
    }
}
