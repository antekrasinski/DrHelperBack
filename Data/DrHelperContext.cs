using DrHelperBack.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrHelperBack.Data
{
    public class DrHelperContext : DbContext
    {
        public DrHelperContext(DbContextOptions<DrHelperContext> opt) : base(opt)
        {

        }

        public DbSet<UserType> user_type { get; set; }
    }
}
