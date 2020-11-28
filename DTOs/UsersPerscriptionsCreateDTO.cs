using System.ComponentModel.DataAnnotations;

namespace DrHelperBack.DTOs
{
    public class UsersPerscriptionsCreateDTO
    {
        [Key]
        public int idUser { get; set; }
        [Key]
        public int idPerscription { get; set; }
    }
}
