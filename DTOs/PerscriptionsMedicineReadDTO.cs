using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrHelperBack.DTOs
{
    public class PerscriptionsMedicineReadDTO
    {
        public int idPerscription { get; set; }
        public int idMedicine { get; set; }
        public string amount { get; set; }
    }
}
