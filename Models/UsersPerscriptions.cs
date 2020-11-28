using System.ComponentModel.DataAnnotations;

namespace DrHelperBack.Models
{
    public class UsersPerscriptions
    {
        [Key]
        public int idUser { get; set; }
        [Key]
        public int idPerscription { get; set; }
    }
}
