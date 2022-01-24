using System;

namespace GenericsAndCollectionsExampleLibrary
{
    public class CustomQueue<T> : IAggregate<T>
    {
        private const int defaultCapacity = 10;

        private T[] _array;
        private int _size;
        
        private int _capacity;
        private int _head;
        private int _tail;

        public CustomQueue()
        {
            _capacity = defaultCapacity;
            _array = new T[defaultCapacity];
            _size = 0;
            _head = -1;
            _tail = 0;
        }

        public bool IsEmpty()  
        {
            return _size == 0;
        }

        public void Enqueue(T newElement)
        {
            if (_size == _capacity)
            {
                T[] newQueue = new T[2 * _capacity];
                Array.Copy(_array, 0, newQueue, 0, _array.Length);
                _array = newQueue;
                _capacity *= 2;
            }
            _size++;
            _array[_tail++ % _capacity] = newElement;
        }

        public T Dequeue()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException();
            }
            _size--;
            return _array[++_head % _capacity];
        }

        public IIterator<T> GetIterator()
        {
            return new CustomIterator<T>(this);
        }

        public int Count
        {
            get
            {
                return _size;
            }
        }

        public T this[int itemIndex] 
        {
            get => _array[itemIndex]; 
            set => _array[itemIndex] = value; 
        }
    }
}