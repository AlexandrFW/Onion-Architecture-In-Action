using GenericsAndCollectionsExampleLibrary;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;

namespace GenericsAndCollectionsApp.Test
{
    public class BinarySearchTest
    {
        [Test]
        public void String_Array_BinarySearch_Should_Return_Index_At_Which_Given_Value_Exists()
        {
            // Assign
            var arrString = new string[] { "1", "d2", "asd3", "4we", "5", "6", "dfr7", "8", "str" };
            var needToBeFound = "asd3";
            var nIndexShouldBe = 5;

            // Act
            Array.Sort(arrString);
            int result = GenericsExamples.BinarySearch(arrString, needToBeFound, new StringComparator());

            // Assert
            Assert.That(nIndexShouldBe, Is.EqualTo(result));
        }

        [Test]
        public void Int_Array_BinarySearch_Should_Return_Index_At_Which_Given_Value_Exists()
{
            // Assign
            var arrInt = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var needToBeFound = 7;
            var nIndexShouldBe = 6;

            // Act
            Array.Sort(arrInt);
            int result = GenericsExamples.BinarySearch(arrInt, needToBeFound, new IntComparator());

            // Assert
            Assert.That(nIndexShouldBe, Is.EqualTo(result));
        }

        [Test]
        public void Int_Array_BinarySearch_Should_Return_Index_Of_First_Element_Zero()
        {
            // Assign
            var arrInt = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var needToBeFound = 1;
            var nIndexShouldBe = 0;

            // Act
            Array.Sort(arrInt);
            int result = GenericsExamples.BinarySearch(arrInt, needToBeFound, new IntComparator());

            // Assert
            Assert.That(nIndexShouldBe, Is.EqualTo(result));
        }

        [Test]
        public void Int_Array_BinarySearch_Should_Return_Index_Of_Last_Element()
        {
            // Assign
            var arrInt = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var needToBeFound = 9;
            var nIndexShouldBe = 8;

            // Act
            Array.Sort(arrInt);
            int result = GenericsExamples.BinarySearch(arrInt, needToBeFound, new IntComparator());

            // Assert
            Assert.That(nIndexShouldBe, Is.EqualTo(result));
        }

        [Test]
        public void Int_Array_BinarySearch_Should_Return_Value_As_Not_Found()
        {
            // Assign
            var arrInt = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var needNotToBeFound = 12;
            var nIndexShouldBe = -1;

            // Act
            Array.Sort(arrInt);
            int result = GenericsExamples.BinarySearch(arrInt, needNotToBeFound, new IntComparator());

            // Assert
            Assert.That(nIndexShouldBe, Is.EqualTo(result));
        }

        [Test]
        public void Int_Array_BinarySearch_Should_Throw_ArgumentException_If_Comparer_Is_Null()
        {
            // Assign
            var arrInt = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var needToBeFound = 9;

            // Assert
            Assert.That(() => GenericsExamples.BinarySearch(arrInt, needToBeFound, null), Throws.ArgumentNullException);
        }

        [Test]
        public void Int_Array_BinarySearch_Should_Throw_ArgumentException_If_Array_Is_Null()
        {
            // Assert
            Assert.That(() => GenericsExamples.BinarySearch(null, 1, new IntComparator()), Throws.ArgumentNullException);
        }
    }
}