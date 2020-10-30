using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DrHelperBack.Models
{
    public class UserType
    {
        [Key]
        public int id_user_type { get; set; }
        [Required]
        [MaxLength(20)]
        public string type { get; set; }
    }
}
