using System.Collections.Generic;

namespace DrHelperBack.Data
{
    public interface IDrHelperRepo<T>
    {
        bool SaveChanges();
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Create(T newOne);
        void Update(T oneToUpdate);
        void Delete(T oneToDelete);
    }
}
