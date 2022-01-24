namespace GenericsAndCollectionsExampleLibrary
{
    public interface IIterator<T>
    {
        T FirstItem { get; }

        T MoveNext();

        T CurrentItem { get; }

        bool IsDone { get; }
    }
}
