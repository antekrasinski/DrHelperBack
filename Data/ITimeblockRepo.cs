using DrHelperBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrHelperBack.Data
{
    public interface ITimeblockRepo
    {
        bool SaveChanges();
        IEnumerable<Timeblock> GetAll();
        Timeblock GetById(int id);
        IEnumerable<Timeblock> GetUsersTimeblocks(int idUser);
        void Create(Timeblock newOne);
        void Update(Timeblock oneToUpdate);
        void Delete(Timeblock oneToDelete);
    }
}
