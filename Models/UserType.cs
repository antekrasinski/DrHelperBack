using System.ComponentModel.DataAnnotations;

namespace DrHelperBack.Models
{
    public class UserType
    {
        [Key]
        public int idUserType { get; set; }
        [Required]
        [MaxLength(20)]
        public string type { get; set; }
    }
}
