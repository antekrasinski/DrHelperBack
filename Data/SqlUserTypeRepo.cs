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

            _context.UserType.Add(newOne);
        }

        public void Delete(UserType oneToDelete)
        {
            if (oneToDelete == null)
            {
                throw new ArgumentNullException(nameof(oneToDelete));
            }
            _context.UserType.Remove(oneToDelete);
        }

        public UserType GetById(int id)
        {
            return _context.UserType.FirstOrDefault(p => p.idUserType == id);
        }

        public IEnumerable<UserType> GetAll()
        {
            return _context.UserType.ToList();
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
