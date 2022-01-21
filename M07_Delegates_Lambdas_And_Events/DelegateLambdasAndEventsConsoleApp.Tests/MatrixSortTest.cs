using NUnit.Framework;

namespace DelegateLambdasAndEventsConsoleApp.Tests
{
    public class MatrixSortTest
    {
        [Test]
        public void CompareByRowSum_Asc_Desc_Test()
        {
            // Assert
            Assert.That(MatrixSort.CompareByRowSum(row1, row2, true), Is.False);
            Assert.That(MatrixSort.CompareByRowSum(row1, row2, false), Is.True);
        }

        [Test]
        public void CompareByRowMin_Asc_Desc_Test()
        {
            // Assert
            Assert.That(MatrixSort.CompareByRowMin(row1, row2, true), Is.False);
            Assert.That(MatrixSort.CompareByRowMin(row1, row2, false), Is.True);
        }

        [Test]
        public void CompareByRowMax_Asc_Desc_Test()
        {
            // Assert
            Assert.That(MatrixSort.CompareByRowMax(row1, row2, true), Is.True);
            Assert.That(MatrixSort.CompareByRowMax(row1, row2, false), Is.False);
        }

        [Test]
        public void CompareByRowSum_Throw_ArgumentException_If_One_Of_Parameters_Is_Not_Valid_Test()
        {
            // The fourth parameter does not make sence due to constantly exist - true or false
            // Assert
            Assert.That(() => MatrixSort.CompareByRowSum(null, row2, true), Throws.ArgumentException);
            Assert.That(() => MatrixSort.CompareByRowSum(row1, null, true), Throws.ArgumentException);
            Assert.That(() => MatrixSort.CompareByRowSum(new int[]{ }, row2, true), Throws.ArgumentException);
            Assert.That(() => MatrixSort.CompareByRowSum(row1, new int[] { }, true), Throws.ArgumentException);
        }

        [Test]
        public void CompareByRowMin_Throw_ArgumentException_If_One_Of_Parameters_Is_Not_Valid_Test()
        {
            // The fourth parameter does not make sence due to constantly exist - true or false
            // Assert
            Assert.That(() => MatrixSort.CompareByRowMin(null, row2, true), Throws.ArgumentException);
            Assert.That(() => MatrixSort.CompareByRowMin(row1, null, true), Throws.ArgumentException);
            Assert.That(() => MatrixSort.CompareByRowMin(new int[] { }, row2, true), Throws.ArgumentException);
            Assert.That(() => MatrixSort.CompareByRowMin(row1, new int[] { }, true), Throws.ArgumentException);
        }

        [Test]
        public void CompareByRowMax_Throw_ArgumentException_If_One_Of_Parameters_Is_Not_Valid_Test()
        {
            // The fourth parameter does not make sence due to constantly exist - true or false
            // Assert
            Assert.That(() => MatrixSort.CompareByRowMax(null, row2, true), Throws.ArgumentException);
            Assert.That(() => MatrixSort.CompareByRowMax(row1, null, true), Throws.ArgumentException);
            Assert.That(() => MatrixSort.CompareByRowMax(new int[] { }, row2, true), Throws.ArgumentException);
            Assert.That(() => MatrixSort.CompareByRowMax(row1, new int[] { }, true), Throws.ArgumentException);
        }

        [Test]
        public void Sort_Method_Should_Throw_ArgumentException_If_Given_Matrix_Or_Delegate_Method_Is_Null_Test()
        {
            // The true parameter does not make sence due to constantly exist - true or false
            // Assert
            Assert.That(() => MatrixSort.Sort(null, true, MatrixSort.CompareByRowSum), Throws.ArgumentException);
            Assert.That(() => MatrixSort.Sort(matrix, true, null), Throws.ArgumentException);
        }

        [Test]
        public void Sort_Method_Should_Sort_Matrix_Asc_By_Sum_Of_Each_Row_Elements_Test()
        {
            // Act
            MatrixSort.Sort(matrix, true, MatrixSort.CompareByRowSum);

            // Assert
            Assert.That(matrix, Is.EqualTo(matrix_sort_by_sum_asc));
        }

        [Test]
        public void Sort_Method_Should_Sort_Matrix_Desc_By_Sum_Of_Each_Row_Elements_Test()
        {
            // Act
            MatrixSort.Sort(matrix, false, MatrixSort.CompareByRowSum);

            // Assert
            Assert.That(matrix, Is.EqualTo(matrix_sort_by_sum_desc));
        }

        [Test]
        public void Sort_Method_Should_Sort_Matrix_Asc_By_Min_Of_Each_Row_Elements_Test()
        {
            // Act
            MatrixSort.Sort(matrix, true, MatrixSort.CompareByRowMin);

            // Assert
            Assert.That(matrix, Is.EqualTo(matrix_sort_by_min_asc));
        }

        [Test]
        public void Sort_Method_Should_Sort_Matrix_Desc_By_Min_Of_Each_Row_Elements_Test()
        {
            // Act
            MatrixSort.Sort(matrix, false, MatrixSort.CompareByRowMin);

            // Assert
            Assert.That(matrix, Is.EqualTo(matrix_sort_by_min_desc));
        }

        [Test]
        public void Sort_Method_Should_Sort_Matrix_Asc_By_Max_Of_Each_Row_Elements_Test()
        {
            // Act
            MatrixSort.Sort(matrix, true, MatrixSort.CompareByRowMax);

            // Assert
            Assert.That(matrix, Is.EqualTo(matrix_sort_by_max_asc));
        }

        [Test]
        public void Sort_Method_Should_Sort_Matrix_Desc_By_Max_Of_Each_Row_Elements_Test()
        {
            // Act
            MatrixSort.Sort(matrix, false, MatrixSort.CompareByRowMax);

            // Assert
            Assert.That(matrix, Is.EqualTo(matrix_sort_by_max_desc));
        }

        readonly int[] row1 = { 1, 9, 5 };
        readonly int[] row2 = { 4, 7, 8 };

        readonly int[,] matrix = new int[,] { { 1, 9, 5 },
                                              { 4, 7, 8 },
                                              { 3, 6, 2 } };

        // Results after sorting by sum of each matrix rows - asc / desc
        readonly int[,] matrix_sort_by_sum_asc = new int[,] { { 3, 6, 2 },
                                                              { 1, 9, 5 },
                                                              { 4, 7, 8 } };

        readonly int[,] matrix_sort_by_sum_desc = new int[,] { { 4, 7, 8 },            
                                                               { 1, 9, 5 },
                                                               { 3, 6, 2 } };

        // Results after sorting by min of each matrix rows - asc / desc
        readonly int[,] matrix_sort_by_min_asc = new int[,] { { 1, 9, 5 },
                                                              { 3, 6, 2 },
                                                              { 4, 7, 8 } };

        readonly int[,] matrix_sort_by_min_desc = new int[,] { { 4, 7, 8 },
                                                               { 3, 6, 2 },
                                                               { 1, 9, 5 }};

        // Results after sorting by max of each matrix rows - asc / desc
        readonly int[,] matrix_sort_by_max_asc = new int[,] { { 3, 6, 2 },
                                                              { 4, 7, 8 },
                                                              { 1, 9, 5 } };

        readonly int[,] matrix_sort_by_max_desc = new int[,] { { 1, 9, 5 },
                                                               { 4, 7, 8 },
                                                               { 3, 6, 2 } };

    }
}