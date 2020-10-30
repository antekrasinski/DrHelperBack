using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrHelperBack.Models;
using Microsoft.AspNetCore.Mvc;

namespace DrHelperBack.Data
{
    public class SqlDrHelperRepo : IDrHelperRepo
    {
        private readonly DrHelperContext _context;

        public SqlDrHelperRepo(DrHelperContext context)
        {
            _context = context;
        }

        public void CreateUserType(UserType type)
        {
            if(type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            _context.user_type.Add(type);
        }

        public void DeleteUserType(UserType type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }
            _context.user_type.Remove(type);
        }

        public UserType GetUserType(int id)
        {
            return _context.user_type.FirstOrDefault(p => p.id_user_type == id);
        }

        public IEnumerable<UserType> GetUserTypes()
        {
            return _context.user_type.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateUserType(UserType type)
        {
            //Pusto
        }
    }
}
