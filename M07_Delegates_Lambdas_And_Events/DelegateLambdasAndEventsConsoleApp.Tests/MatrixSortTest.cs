using NUnit.Framework;

namespace DelegateLambdasAndEventsConsoleApp.Tests
{
    public class MatrixSortTest
    {
        [Test]
        public void CompareByRowSum_Asc_Desc_Test()
        {
            // Act
            bool IsLess = MatrixSort.CompareByRowSum(row1, row2, nRowLength, IsAsc);
            bool IsGreater = MatrixSort.CompareByRowSum(row1, row2, nRowLength, IsDesc);

            // Assert
            Assert.That(IsLess, Is.True);
            Assert.That(IsGreater, Is.False);
        }

        [Test]
        public void CompareByRowMin_Asc_Desc_Test()
        {
            // Act
            bool IsLess = MatrixSort.CompareByRowMin(row1, row2, nRowLength, IsAsc);
            bool IsGreater = MatrixSort.CompareByRowMin(row1, row2, nRowLength, IsDesc);

            // Assert
            Assert.That(IsLess, Is.True);
            Assert.That(IsGreater, Is.False);
        }

        [Test]
        public void CompareByRowMax_Asc_Desc_Test()
        {
            // Act
            bool IsLess = MatrixSort.CompareByRowMax(row1, row2, nRowLength, IsAsc);
            bool IsGreater = MatrixSort.CompareByRowMax(row1, row2, nRowLength, IsDesc);

            // Assert
            Assert.That(IsLess, Is.False);
            Assert.That(IsGreater, Is.True);
        }

        [Test]
        public void CompareByRowSum_Throw_ArgumentException_If_One_Of_Parameters_Is_Not_Valid_Test()
        {
            // The fourth parameter does not make sence due to constantly exist - true or false
            // Assert
            Assert.That(() => MatrixSort.CompareByRowSum(null, row2, nRowLength, IsAsc), Throws.ArgumentException);
            Assert.That(() => MatrixSort.CompareByRowSum(row1, null, nRowLength, IsAsc), Throws.ArgumentException);
            Assert.That(() => MatrixSort.CompareByRowSum(row1, row2, 0, IsAsc), Throws.ArgumentException);
            Assert.That(() => MatrixSort.CompareByRowSum(new int[]{ }, row2, nRowLength, IsAsc), Throws.ArgumentException);
            Assert.That(() => MatrixSort.CompareByRowSum(row1, new int[] { }, nRowLength, IsAsc), Throws.ArgumentException);
        }

        [Test]
        public void CompareByRowMin_Throw_ArgumentException_If_One_Of_Parameters_Is_Not_Valid_Test()
        {
            // The fourth parameter does not make sence due to constantly exist - true or false
            // Assert
            Assert.That(() => MatrixSort.CompareByRowMin(null, row2, nRowLength, IsAsc), Throws.ArgumentException);
            Assert.That(() => MatrixSort.CompareByRowMin(row1, null, nRowLength, IsAsc), Throws.ArgumentException);
            Assert.That(() => MatrixSort.CompareByRowMin(row1, row2, 0, IsAsc), Throws.ArgumentException);
            Assert.That(() => MatrixSort.CompareByRowMin(new int[] { }, row2, nRowLength, IsAsc), Throws.ArgumentException);
            Assert.That(() => MatrixSort.CompareByRowMin(row1, new int[] { }, nRowLength, IsAsc), Throws.ArgumentException);
        }

        [Test]
        public void CompareByRowMax_Throw_ArgumentException_If_One_Of_Parameters_Is_Not_Valid_Test()
        {
            // The fourth parameter does not make sence due to constantly exist - true or false
            // Assert
            Assert.That(() => MatrixSort.CompareByRowMax(null, row2, nRowLength, IsAsc), Throws.ArgumentException);
            Assert.That(() => MatrixSort.CompareByRowMax(row1, null, nRowLength, IsAsc), Throws.ArgumentException);
            Assert.That(() => MatrixSort.CompareByRowMax(row1, row2, 0, IsAsc), Throws.ArgumentException);
            Assert.That(() => MatrixSort.CompareByRowMax(new int[] { }, row2, nRowLength, IsAsc), Throws.ArgumentException);
            Assert.That(() => MatrixSort.CompareByRowMax(row1, new int[] { }, nRowLength, IsAsc), Throws.ArgumentException);
        }

        [Test]
        public void Sort_Method_Should_Throw_ArgumentException_If_Given_Matrix_Or_Delegate_Method_Is_Null_Test()
        {
            // The IsAsc parameter does not make sence due to constantly exist - true or false
            // Assert
            Assert.That(() => MatrixSort.Sort(null, IsAsc, MatrixSort.CompareByRowSum), Throws.ArgumentException);
            Assert.That(() => MatrixSort.Sort(matrix, IsAsc, null), Throws.ArgumentException);
        }

        [Test]
        public void Countdown_Publisher_Should_Raise_Event_And_Subscriber_Should_Get_It_Test()
        {
            // Assign
            bool IsEventRaised = false;
            var countDown = new Countdown(1000);
            countDown.OnCounted += (e) => { IsEventRaised = true; }; //subscriber1.countDown_Progress;

            // Act
            countDown.Count();

            // Assert
            Assert.That(IsEventRaised, Is.True);
        }

        readonly int[,] matrix = new int[,] { { 1, 9, 5 },
                                              { 4, 7, 8 },
                                              { 3, 6, 2 } };

        readonly int[] row1 = { 1, 9, 5 };
        readonly int[] row2 = { 4, 7, 8 };
        readonly int nRowLength = 3;
        readonly bool IsAsc = true;
        readonly bool IsDesc = false;
    }
}