using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrHelperBack.DTOs
{
    public class TimeblockReadDTO
    {
        public int idTimeblock { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public bool avaliable { get; set; }
        public int idUser { get; set; }
        public int idAppointment { get; set; }
    }
}
