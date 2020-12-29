using DrHelperBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrHelperBack.Data
{
    public interface IUserRepo
    {
        User Authenticate(string username, string password);
        bool SaveChanges();
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Create(User newOne, string password);
        void Update(User oneToUpdate, string password);
        void Delete(User oneToDelete);

    }
}
