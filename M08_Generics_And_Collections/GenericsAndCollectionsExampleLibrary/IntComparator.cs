using System.Collections.Generic;

namespace GenericsAndCollectionsExampleLibrary
{
    public class IntComparator : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return x.CompareTo(y);
        }
    }
}