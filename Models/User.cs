using System.ComponentModel.DataAnnotations;

namespace DrHelperBack.Models
{
    public class User
    {
        [Key]
        public int id_user { get; set; }
        [Required]
        [MaxLength(50)]
        public string username { get; set; }
        [Required]
        [MaxLength(50)]
        public string password { get; set; }
        [Required]
        [MaxLength(200)]
        public string description { get; set; }
        [Required]
        public int id_user_type { get; set; }
    }
}
