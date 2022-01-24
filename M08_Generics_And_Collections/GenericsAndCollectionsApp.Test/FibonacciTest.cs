using GenericsAndCollectionsExampleLibrary;
using NUnit.Framework;

namespace GenericsAndCollectionsApp.Test
{
    public class FibonacciTest
    {
        [Test]
        public void Fibonacci_Should_Display_Predefined_Secquence_Test()
        {
            // Assign
            var actual = new FibonacciSequinceYieldExamples(10);
            var expected = new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55 };
            var i = 0;

            // Assert
            foreach(var result in actual)
            {
                Assert.That(result, Is.EqualTo(expected[i]));
                i++;
            }
        }
    }
}