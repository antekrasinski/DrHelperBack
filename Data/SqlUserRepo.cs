using DrHelperBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DrHelperBack.Data
{
    public class SqlUserRepo : IDrHelperRepo<User>
    {
        private readonly DrHelperContext _context;

        public SqlUserRepo(DrHelperContext context)
        {
            _context = context;
        }

        public void Create(User newOne)
        {
            if (newOne == null)
            {
                throw new ArgumentNullException(nameof(newOne));
            }

            _context.User.Add(newOne);
        }

        public void Delete(User oneToDelete)
        {
            if (oneToDelete == null)
            {
                throw new ArgumentNullException(nameof(oneToDelete));
            }
            _context.User.Remove(oneToDelete);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.User.ToList();
        }

        public User GetById(int id)
        {
            return _context.User.FirstOrDefault(p => p.idUser == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(User oneToUpdate)
        {
            //Pusto
        }
    }
}
