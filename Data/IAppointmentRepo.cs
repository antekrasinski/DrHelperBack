using DrHelperBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrHelperBack.Data
{
    public interface IAppointmentRepo
    {
        bool SaveChanges();
        IEnumerable<Appointment> GetAll();
        Appointment GetById(int id);
        void Create(Appointment newOne);
        void Update(Appointment oneToUpdate);
        void Delete(Appointment oneToDelete);
    }
}
