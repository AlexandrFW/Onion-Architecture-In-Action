using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface ILectureStudentsHomeworksRepository<T> where T : class
    {
        void Delete(string id);

        void Edit(string id, T person);

        T? Get(string id);

        IEnumerable<T> GetAll();

        string New(T person);
    }
}