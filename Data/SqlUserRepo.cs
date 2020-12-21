using DrHelperBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DrHelperBack.Data
{
    public class SqlUserRepo : IUserRepo
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

        public User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _context.User.SingleOrDefault(x => x.username == username);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (user.password != password)
                return null;

            // authentication successful
            return user;
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
