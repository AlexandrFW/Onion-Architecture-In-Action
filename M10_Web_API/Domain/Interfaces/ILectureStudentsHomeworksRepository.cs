namespace Domain.Interfaces
{
    public interface ILectureStudentsHomeworksRepository<T> where T : class
    {
        void Delete(string id);

        void Edit(T person);

        T? Get(string id);

        IEnumerable<T> GetAll();

        string New(T person);
    }
}