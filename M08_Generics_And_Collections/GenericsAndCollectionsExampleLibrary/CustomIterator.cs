using System;

namespace GenericsAndCollectionsExampleLibrary
{
    public class CustomIterator<T> : IIterator<T>
    {
        IAggregate<T> _aggregate = null;
        int _currentIndex = 0;

        public CustomIterator(IAggregate<T> aggregate)
        {
            _aggregate = aggregate;
        }

        public T Current => _aggregate[_currentIndex];

        public T FirstItem
        {
            get
            {
                _currentIndex = 0;
                return _aggregate[_currentIndex];
            }
        }

        public T MoveNext()
        {
            _currentIndex++;

            if (IsDone == false)
            {
                return _aggregate[_currentIndex];
            }
            else
            {
                return default;
            }
        }

        public T CurrentItem
        {
            get
            {
                return _aggregate[_currentIndex];
            }
        }

        public bool IsDone
        {
            get
            {
                if (_currentIndex < _aggregate.Count)
                {
                    return false;
                }
                return true;
            }
        }       
    }
}