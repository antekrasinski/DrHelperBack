﻿using System.ComponentModel.DataAnnotations;

namespace DrHelperBack.DTOs
{
    public class UserTypeCreateDTO
    {
        [Required]
        [MaxLength(20)]
        public string type { get; set; }
    }
}
