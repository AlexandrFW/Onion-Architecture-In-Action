namespace Domain.Interfaces
{
    public interface ILectureStudentsHomeworksServices<T>
    {
        T? Get(string id);

        IReadOnlyCollection<T> GetAll();

        string New(T person);

        string Edit(T person);

        void Delete(string id);
    }
}