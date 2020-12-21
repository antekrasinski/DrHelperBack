using DrHelperBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrHelperBack.Data
{
    public class SqlTimeblockRepo : ITimeblockRepo
    {
        private readonly DrHelperContext _context;

        public SqlTimeblockRepo(DrHelperContext context)
        {
            _context = context;
        }

        public void Create(Timeblock newOne)
        {
            if (newOne == null)
            {
                throw new ArgumentNullException(nameof(newOne));
            }

            _context.Timeblock.Add(newOne);
        }

        public void Delete(Timeblock oneToDelete)
        {
            if (oneToDelete == null)
            {
                throw new ArgumentNullException(nameof(oneToDelete));
            }
            _context.Timeblock.Remove(oneToDelete);
        }

        public Timeblock GetById(int id)
        {
            return _context.Timeblock.FirstOrDefault(p => p.idTimeblock == id);
        }

        public IEnumerable<Timeblock> GetAll()
        {
            return _context.Timeblock.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(Timeblock oneToUpdate)
        {
            //Pusto
        }

        public IEnumerable<Timeblock> GetUsersTimeblocks(int idUser)
        {
            return _context.Timeblock.Where(t => t.idUser == idUser).ToList();
        }

        public IEnumerable<Timeblock> GetTimeblocksByAppointmentId(int idAppointment)
        {
            return _context.Timeblock.Where(t => t.idAppointment == idAppointment).ToList();
        }
    }
}
