using System.Collections;

namespace GenericsAndCollectionsExampleLibrary
{
    public class FibonacciSequinceYieldExamples : IEnumerable
    {
        private readonly int _sequenceSize;

        public FibonacciSequinceYieldExamples(int sequenceSize)
        {
            _sequenceSize = sequenceSize;
        }

        public IEnumerator GetEnumerator()
        {
            int n1 = 0;
            int n2 = 1;
            int count = 0;

            while (count <= _sequenceSize)
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