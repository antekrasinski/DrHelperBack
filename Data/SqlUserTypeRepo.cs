using DrHelperBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DrHelperBack.Data
{
    public class SqlUserTypeRepo : IDrHelperRepo<UserType>
    {
        private readonly DrHelperContext _context;

        public SqlUserTypeRepo(DrHelperContext context)
        {
            _context = context;
        }

        public void Create(UserType newOne)
        {
            if (newOne == null)
            {
                throw new ArgumentNullException(nameof(newOne));
            }

            _context.user_type.Add(newOne);
        }

        public void Delete(UserType oneToDelete)
        {
            if (oneToDelete == null)
            {
                throw new ArgumentNullException(nameof(oneToDelete));
            }
            _context.user_type.Remove(oneToDelete);
        }

        public UserType GetById(int id)
        {
            return _context.user_type.FirstOrDefault(p => p.id_user_type == id);
        }

        public IEnumerable<UserType> GetAll()
        {
            return _context.user_type.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(UserType oneToUpdate)
        {
            //Pusto
        }
    }
}
