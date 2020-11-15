using System.ComponentModel.DataAnnotations;

namespace DrHelperBack.DTOs
{
    public class DiseaseCreateDTO
    {
        [Required]
        [MaxLength(100)]
        public string name { get; set; }
    }
}

