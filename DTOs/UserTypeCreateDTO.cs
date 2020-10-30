﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DrHelperBack.DTOs
{
    public class UserTypeCreateDTO
    {
        [Required]
        [MaxLength(20)]
        public string type { get; set; }
    }
}