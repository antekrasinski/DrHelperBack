using DrHelperBack.Models;
using System.Collections.Generic;

namespace DrHelperBack.Data
{
    public interface IUsersDiseases
    {
        bool SaveChanges();
        IEnumerable<UsersDiseases> GetUsersDiseases(int idUser);
        UsersDiseases GetByIds(int idUser, int idDisease);
        void Create(UsersDiseases newOne);
        void Update(UsersDiseases oneToUpdate);
        void Delete(UsersDiseases oneToDelete);
    }
}
