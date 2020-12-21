using DrHelperBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrHelperBack.Data
{
    public class SqlUsersDiseasesRepo : IUsersDiseases
    {
        private readonly DrHelperContext _context;

        public SqlUsersDiseasesRepo(DrHelperContext context)
        {
            _context = context;
        }
        public void Create(UsersDiseases newOne)
        {
            if (newOne == null)
            {
                throw new ArgumentNullException(nameof(newOne));
            }
            _context.UsersDiseases.Add(newOne);
        }

        public void Delete(UsersDiseases oneToDelete)
        {

            if (oneToDelete == null)
            {
                throw new ArgumentNullException(nameof(oneToDelete));
            }
            _context.UsersDiseases.Remove(oneToDelete);
        }

        public UsersDiseases GetById(int idUsersDiseases)
        {
            return _context.UsersDiseases.FirstOrDefault(p => p.idUsersDiseases == idUsersDiseases);
        }

        public IEnumerable<UsersDiseases> GetUsersDiseases(int idUser)
        {
            return _context.UsersDiseases.Where(p => p.idUser == idUser).ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(UsersDiseases oneToUpdate)
        {
            //pusto
        }
    }
}
