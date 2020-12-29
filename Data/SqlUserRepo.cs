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

        public void Create(User newOne, string password)
        {
            if (newOne == null)
            {
                throw new ArgumentNullException(nameof(newOne));
            }

            if(_context.User.Any(u=>u.username == newOne.username))
            {
                throw new ApplicationException("Username already exists.");
            }
            byte[] passwordHash;
            byte[] passwordSalt;

            CreateHash(password, out passwordHash, out passwordSalt);

            newOne.PasswordHash = passwordHash;
            newOne.PasswordSalt = passwordSalt;

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
            /*if (user.password != password)
                return null;
            */
            if(!VerifyHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }

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

        public void Update(User oneToUpdate, string password)
        {
            if (_context.User.Any(u => u.username == oneToUpdate.username && u.idUser != oneToUpdate.idUser))
            {
                throw new ApplicationException("Username already exists.");
            }

            byte[] passwordHash;
            byte[] passwordSalt;

            CreateHash(password, out passwordHash, out passwordSalt);

            oneToUpdate.PasswordHash = passwordHash;
            oneToUpdate.PasswordSalt = passwordSalt;

        }

        private static void CreateHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyHash(string password, byte[] hash, byte[] salt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(salt))
            {
                var tempHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i = 0; i<tempHash.Length; i++)
                {
                    if(tempHash[i] != hash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
