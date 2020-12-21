using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrHelperBack.DTOs
{
    public class PrescriptionReadDTO
    {
        public int idPrescription { get; set; }
        public DateTime prescriptionDate { get; set; }
    }
}
