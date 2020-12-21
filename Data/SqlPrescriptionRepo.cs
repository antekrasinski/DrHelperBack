using DrHelperBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrHelperBack.Data
{
    public class SqlPrescriptionRepo : IPrescriptionRepo
    {
        private readonly DrHelperContext _context;

        public SqlPrescriptionRepo(DrHelperContext context)
        {
            _context = context;
        }

        public void ConnectMedicine(PrescriptionsMedicine newOne)
        {
            if (newOne == null)
            {
                throw new ArgumentNullException(nameof(newOne));
            }

            _context.PrescriptionsMedicine.Add(newOne);
        }

        public void ConnectUsers(UsersPrescriptions newOne)
        {
            if (newOne == null)
            {
                throw new ArgumentNullException(nameof(newOne));
            }

            _context.UsersPrescriptions.Add(newOne);
        }

        public void Create(Prescription newOne)
        {
            if (newOne == null)
            {
                throw new ArgumentNullException(nameof(newOne));
            }

            _context.Prescription.Add(newOne);
        }

        public void DeleteConnectionMedicine(PrescriptionsMedicine oneToDelete)
        {
            if (oneToDelete == null)
            {
                throw new ArgumentNullException(nameof(oneToDelete));
            }
            _context.PrescriptionsMedicine.Remove(oneToDelete);
        }

        public void DeleteUsersConnections(UsersPrescriptions oneToDelete)
        {
            if (oneToDelete == null)
            {
                throw new ArgumentNullException(nameof(oneToDelete));
            }
            _context.UsersPrescriptions.Remove(oneToDelete);
        }

        public void DeleteMedicineConnections(PrescriptionsMedicine oneToDelete)
        {
            if (oneToDelete == null)
            {
                throw new ArgumentNullException(nameof(oneToDelete));
            }
            _context.PrescriptionsMedicine.Remove(oneToDelete);
        }

        public void DeletePrescription(Prescription oneToDelete)
        {
            if (oneToDelete == null)
            {
                throw new ArgumentNullException(nameof(oneToDelete));
            }
            _context.Prescription.Remove(oneToDelete);
        }

        public Prescription GetPrescriptionById(int idPrescription)
        {
            return _context.Prescription.FirstOrDefault(p => p.idPrescription == idPrescription);
        }

        public IEnumerable<UsersPrescriptions> GetUsersConnections()
        {
            return _context.UsersPrescriptions.ToList();
        }

        public IEnumerable<PrescriptionsMedicine> GetMedicine(int idPrescription)
        {
            return _context.PrescriptionsMedicine.Where(p => p.idPrescription == idPrescription).ToList();
        }

        public IEnumerable<UsersPrescriptions> GetPrescriptions(int idUser)
        {
            return _context.UsersPrescriptions.Where(p => p.idUser == idUser).ToList();
        }

        public IEnumerable<UsersPrescriptions> GetPrescriptionsUsersByPrescriptionsId(int idPrescription)
        {
            return _context.UsersPrescriptions.Where(p => p.idPrescription == idPrescription).ToList();
        }

        public PrescriptionsMedicine GetPrescriptionsMedicineByIds(int idPrescription, int idMedicine)
        {
            return _context.PrescriptionsMedicine.FirstOrDefault(p => p.idPrescription == idPrescription && p.idMedicine == idMedicine);
        }

        public UsersPrescriptions GetUsersPrescriptionByIds(int idUser, int idPrescription)
        {
            return _context.UsersPrescriptions.FirstOrDefault(p => p.idPrescription == idPrescription && p.idUser == idUser);
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
