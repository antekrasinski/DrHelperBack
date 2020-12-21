using DrHelperBack.Models;
using System.Collections.Generic;

namespace DrHelperBack.Data
{
    public interface IPrescriptionRepo
    {
        bool SaveChanges();
        IEnumerable<UsersPrescriptions> GetPrescriptions(int idUser);
        IEnumerable<PrescriptionsMedicine> GetMedicine(int idPrescription);
        IEnumerable<UsersPrescriptions> GetUsersConnections();
        Prescription GetPrescriptionById(int idPrescription);
        PrescriptionsMedicine GetPrescriptionsMedicineByIds(int idPrescription, int idMedicine);
        UsersPrescriptions GetUsersPrescriptionByIds(int idUser, int idPrescription);
        IEnumerable<UsersPrescriptions> GetPrescriptionsUsersByPrescriptionsId(int idPrescription);
        void Create(Prescription newOne);
        void ConnectMedicine(PrescriptionsMedicine newOne);
        void ConnectUsers(UsersPrescriptions newOne);
        void Update();
        void DeletePrescription(Prescription oneToDelete);
        void DeleteConnectionMedicine(PrescriptionsMedicine oneToDelete);
        void DeleteMedicineConnections(PrescriptionsMedicine oneToDelete);
        void DeleteUsersConnections(UsersPrescriptions oneToDelete);
    }
}
