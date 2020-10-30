using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DrHelperBack.DTOs
{
    public class UserTypeReadDTO
    {
        public int id_user_type { get; set; }
        public string type { get; set; }
    }

}
