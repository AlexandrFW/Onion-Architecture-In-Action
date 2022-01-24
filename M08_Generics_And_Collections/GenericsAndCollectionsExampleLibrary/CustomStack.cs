using System;

namespace GenericsAndCollectionsExampleLibrary
{
    public class CustomStack<T> : IAggregate<T>
    {
        private const int N = 10;
        private T[] _items;
        private int _count;

        public CustomStack()
        {
            _items = new T[N];
        }

        public CustomStack(int length)
        {
            _items = new T[length];
        }

        public bool IsEmpty
        {
            get { return _count == 0; }
        }

        public int Count
        {
            get { return _count; }
        }

        public T this[int itemIndex] 
        { 
            get => _items[itemIndex]; 
            set => _items[itemIndex] = value; 
        }

        public void Push(T item)
        {
            if (_count == _items.Length)
                throw new InvalidOperationException("Переполнение стека");
            _items[_count++] = item;
        }

        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Стек пуст");
            T item = _items[--_count];
            _items[_count] = default; // сбрасываем ссылку
            return item;
        }
        
        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Стек пуст");
            return _items[_count - 1];
        }

        public IIterator<T> GetIterator()
        {
            return new CustomIterator<T>(this);
        }
    }
}