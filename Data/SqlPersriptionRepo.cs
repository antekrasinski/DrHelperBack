using DrHelperBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrHelperBack.Data
{
    public class SqlPersriptionRepo : IPerscriptionRepo
    {
        private readonly DrHelperContext _context;

        public SqlPersriptionRepo(DrHelperContext context)
        {
            _context = context;
        }

        public void ConnectMedicine(PerscriptionsMedicine newOne)
        {
            if (newOne == null)
            {
                throw new ArgumentNullException(nameof(newOne));
            }

            _context.PerscriptionsMedicine.Add(newOne);
        }

        public void ConnectUsers(UsersPerscriptions newOne)
        {
            if (newOne == null)
            {
                throw new ArgumentNullException(nameof(newOne));
            }

            _context.UsersPerscriptions.Add(newOne);
        }

        public void Create(Perscription newOne)
        {
            if (newOne == null)
            {
                throw new ArgumentNullException(nameof(newOne));
            }

            _context.Perscription.Add(newOne);
        }

        public void DeleteConnectionMedicine(PerscriptionsMedicine oneToDelete)
        {
            if (oneToDelete == null)
            {
                throw new ArgumentNullException(nameof(oneToDelete));
            }
            _context.PerscriptionsMedicine.Remove(oneToDelete);
        }

        public void DeleteUsersConnections(UsersPerscriptions oneToDelete)
        {
            if (oneToDelete == null)
            {
                throw new ArgumentNullException(nameof(oneToDelete));
            }
            _context.UsersPerscriptions.Remove(oneToDelete);
        }

        public void DeleteMedicineConnections(PerscriptionsMedicine oneToDelete)
        {
            if (oneToDelete == null)
            {
                throw new ArgumentNullException(nameof(oneToDelete));
            }
            _context.PerscriptionsMedicine.Remove(oneToDelete);
        }

        public void DeletePerscription(Perscription oneToDelete)
        {
            if (oneToDelete == null)
            {
                throw new ArgumentNullException(nameof(oneToDelete));
            }
            _context.Perscription.Remove(oneToDelete);
        }

        public Perscription GetPerscriptionById(int idPerscription)
        {
            return _context.Perscription.FirstOrDefault(p => p.idPerscription == idPerscription);
        }

        public IEnumerable<UsersPerscriptions> GetUsersConnections()
        {
            return _context.UsersPerscriptions.ToList();
        }

        public IEnumerable<PerscriptionsMedicine> GetMedicine(int idPerscription)
        {
            return _context.PerscriptionsMedicine.Where(p => p.idPerscription == idPerscription).ToList();
        }

        public IEnumerable<UsersPerscriptions> GetPerscriptions(int idUser)
        {
            return _context.UsersPerscriptions.Where(p => p.idUser == idUser).ToList();
        }

        public PerscriptionsMedicine GetPerscriptionsMedicineByIds(int idPerscription, int idMedicine)
        {
            return _context.PerscriptionsMedicine.FirstOrDefault(p => p.idPerscription == idPerscription && p.idMedicine == idMedicine);
        }

        public UsersPerscriptions GetUsersPerscriptionByIds(int idUser, int idPerscription)
        {
            return _context.UsersPerscriptions.FirstOrDefault(p => p.idPerscription == idPerscription && p.idUser == idUser);
        }


        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update()
        {
 
        }
    }
}
