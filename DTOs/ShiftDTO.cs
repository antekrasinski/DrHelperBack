using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrHelperBack.DTOs
{
    public class ShiftDTO
    {
        public string shiftStart { get; set; }
        public string shiftEnd { get; set; }
        public string appointmentSpan { get; set; }
        public int idUser { get; set; }
    }
}
