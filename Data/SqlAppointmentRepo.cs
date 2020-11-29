using DrHelperBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrHelperBack.Data
{
    public class SqlAppointmentRepo : IAppointmentRepo
    {
        private readonly DrHelperContext _context;

        public SqlAppointmentRepo(DrHelperContext context)
        {
            _context = context;
        }

        public void Create(Appointment newOne)
        {
            if (newOne == null)
            {
                throw new ArgumentNullException(nameof(newOne));
            }

            _context.Appointment.Add(newOne);
        }

        public void Delete(Appointment oneToDelete)
        {
            if (oneToDelete == null)
            {
                throw new ArgumentNullException(nameof(oneToDelete));
            }
            _context.Appointment.Remove(oneToDelete);
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _context.Appointment.ToList();
        }

        public Appointment GetById(int id)
        {
            return _context.Appointment.FirstOrDefault(p => p.idAppointment == id);
        }

        public IEnumerable<UsersAppointments> GetUsersAppointments(int idUser)
        {
            return _context.UsersAppointments.Where(t => t.idUser == idUser).ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(Appointment oneToUpdate)
        {
        }
    }
}
