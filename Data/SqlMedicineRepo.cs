using DrHelperBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DrHelperBack.Data
{
    public class SqlMedicineRepo : IDrHelperRepo<Medicine>
    {
        private readonly DrHelperContext _context;

        public SqlMedicineRepo(DrHelperContext context)
        {
            _context = context;
        }

        public void Create(Medicine newOne)
        {
            if (newOne == null)
            {
                throw new ArgumentNullException(nameof(newOne));
            }

            _context.medicine.Add(newOne);
        }

        public void Delete(Medicine oneToDelete)
        {
            if (oneToDelete == null)
            {
                throw new ArgumentNullException(nameof(oneToDelete));
            }
            _context.medicine.Remove(oneToDelete);
        }

        public Medicine GetById(int id)
        {
            return _context.medicine.FirstOrDefault(p => p.id_medicine == id);
        }

        public IEnumerable<Medicine> GetAll()
        {
            return _context.medicine.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(Medicine oneToUpdate)
        {
            //Pusto
        }
    }

}
