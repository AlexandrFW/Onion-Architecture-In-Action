using System;
using System.Collections.Generic;

namespace GenericsAndCollectionsExampleLibrary
{
    public static class GenericsExamples
    {
        public static int BinarySearch<T>(T[] array, T searchFor, IComparer<T> comparer) 
        {
            if (comparer == null)
                throw new ArgumentException("Comparer should not be null");

            if (array == null)
                throw new ArgumentException("Array should not be null");

            int high, low, mid;
            high = array.Length - 1;
            low = 0;
            if (array[0].Equals(searchFor))
                return 0;
            else if (array[high].Equals(searchFor))
                return high;
            else
            {
                while (low <= high)
                {
                    mid = (high + low) / 2;
                    if (comparer.Compare(array[mid], searchFor) == 0)
                        return mid;
                    else if (comparer.Compare(array[mid], searchFor) > 0)
                        high = mid - 1;
                    else
                        low = mid + 1;
                }
                return -1;
            }
        }
    }
}