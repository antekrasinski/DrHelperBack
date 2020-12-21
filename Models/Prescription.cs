using System;
using System.ComponentModel.DataAnnotations;

namespace DrHelperBack.Models
{
    public class Prescription
    {
        [Key]
        public int idPrescription { get; set; }
        [Required]
        public DateTime prescriptionDate { get; set; }
    }
}
