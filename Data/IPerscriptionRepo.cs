using DrHelperBack.Models;
using System.Collections.Generic;

namespace DrHelperBack.Data
{
    public interface IPerscriptionRepo
    {
        bool SaveChanges();
        IEnumerable<UsersPerscriptions> GetPerscriptions(int idUser);
        IEnumerable<PerscriptionsMedicine> GetMedicine(int idPerscription);
        IEnumerable<UsersPerscriptions> GetUsersConnections();
        Perscription GetPerscriptionById(int idPerscription);
        PerscriptionsMedicine GetPerscriptionsMedicineByIds(int idPerscription, int idMedicine);
        UsersPerscriptions GetUsersPerscriptionByIds(int idUser, int idPerscription);
        void Create(Perscription newOne);
        void ConnectMedicine(PerscriptionsMedicine newOne);
        void ConnectUsers(UsersPerscriptions newOne);
        void Update();
        void DeletePerscription(Perscription oneToDelete);
        void DeleteConnectionMedicine(PerscriptionsMedicine oneToDelete);
        void DeleteMedicineConnections(PerscriptionsMedicine oneToDelete);
        void DeleteUsersConnections(UsersPerscriptions oneToDelete);
    }
}
