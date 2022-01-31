using System.Collections;
using System.Collections.Generic;

namespace GenericsAndCollectionsExampleLibrary
{
    public static class FibonacciSequenceYieldExamples 
    {
        public static IEnumerable<int> GetEnumerator(int sequenceSize)
        {
            int n1 = 0;
            int n2 = 1;
            int count = 0;

            while (count <= sequenceSize)
            {
                var n1Temp = n1;
                n1 = n2;
                n2 = n1Temp + n2;
                ++count;

                yield return n2 - n1;
            }
        }
    }
}