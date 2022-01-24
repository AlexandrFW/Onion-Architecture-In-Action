namespace GenericsAndCollectionsExampleLibrary
{
    public interface IAggregate<T>
    {
        IIterator<T> GetIterator();

        public T this[int itemIndex] { get; set; }

        int Count { get; }
    }
}