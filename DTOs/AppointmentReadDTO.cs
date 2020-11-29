using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrHelperBack.DTOs
{
    public class AppointmentReadDTO
    {
        public int idAppointment { get; set; }
        public string description { get; set; }
        public int idTimeblock { get; set; }
    }
}
