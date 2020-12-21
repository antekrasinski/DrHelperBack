using System.ComponentModel.DataAnnotations;

namespace DrHelperBack.Models
{
    public class User
    {
        [Key]
        public int idUser { get; set; }
        [Required]
        [MaxLength(50)]
        public string username { get; set; }
        [Required]
        [MaxLength(50)]
        public string password { get; set; }
        [MaxLength(50)]
        public string name { get; set; }
        [MaxLength(100)]
        public string surname { get; set; }
        [MaxLength(200)]
        public string description { get; set; }
        [Required]
        public int idUserType { get; set; }
    }
}
