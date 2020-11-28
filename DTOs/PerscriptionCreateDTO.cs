using System.ComponentModel.DataAnnotations;

namespace DrHelperBack.DTOs
{
    public class PerscriptionCreateDTO
    {
        [Required]
        public string perscriptionDate { get; set; }
    }
}
