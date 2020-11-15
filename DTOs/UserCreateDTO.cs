using System.ComponentModel.DataAnnotations;

namespace DrHelperBack.DTOs
{
    public class UserCreateDTO
    {
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
