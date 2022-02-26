using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IServices<T>
    {
        T? Get(int id);

        IReadOnlyCollection<T> GetAll();

        int New(T person);

        int Edit(T person);

        void Delete(int id);
    }
}