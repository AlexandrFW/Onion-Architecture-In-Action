using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Delete(int id);

        void Edit(int id, T person);

        T? Get(int id);

        IEnumerable<T> GetAll();

        int New(T person);
    }
}