using DrHelperBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrHelperBack.Data
{
    public interface IDrHelperRepo
    {
        bool SaveChanges();
        IEnumerable<UserType> GetUserTypes();

        UserType GetUserType(int id);

        void CreateUserType(UserType type);
        void UpdateUserType(UserType type);
        void DeleteUserType(UserType type);
    }
}
