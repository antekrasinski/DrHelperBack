using DrHelperBack.Models;
using System.Collections.Generic;

namespace DrHelperBack.Data
{
    public interface IUsersDiseases
    {
        bool SaveChanges();
        IEnumerable<UsersDiseases> GetUsersDiseases(int idUser);
        UsersDiseases GetById(int idUsersDiseases);
        void Create(UsersDiseases newOne);
        void Update(UsersDiseases oneToUpdate);
        void Delete(UsersDiseases oneToDelete);
    }
}
