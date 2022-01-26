using System.Collections.Generic;

namespace GenericsAndCollectionsExampleLibrary
{
    public class StringComparator : IComparer<string>
    {
        int IComparer<string>.Compare(string x, string y)
        {
            return x.CompareTo(y);
        }
    }
}