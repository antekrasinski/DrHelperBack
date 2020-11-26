using DrHelperBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DrHelperBack.Data
{
    public class SqlDiseaseRepo : IDrHelperRepo<Disease>
    {
        private readonly DrHelperContext _context;

        public SqlDiseaseRepo(DrHelperContext context)
        {
            _context = context;
        }

        public void Create(Disease newOne)
        {
            if (newOne == null)
            {
                throw new ArgumentNullException(nameof(newOne));
            }

            _context.Disease.Add(newOne);
        }

        public void Delete(Disease oneToDelete)
        {
            if (oneToDelete == null)
            {
                throw new ArgumentNullException(nameof(oneToDelete));
            }
            _context.Disease.Remove(oneToDelete);
        }

        public Disease GetById(int id)
        {
            return _context.Disease.FirstOrDefault(p => p.idDisease == id);
        }

        public IEnumerable<Disease> GetAll()
        {
            return _context.Disease.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(Disease oneToUpdate)
        {
            //Pusto
        }
    }
}
