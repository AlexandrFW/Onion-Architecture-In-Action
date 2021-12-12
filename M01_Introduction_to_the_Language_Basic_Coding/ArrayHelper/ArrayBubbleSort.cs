using System;

namespace ArrayHelper
{
    public static class ArrayBubbleSort
    {
        /// <summary>
        /// Sort ascending one-dimension array
        /// </summary>
        /// <param name="arrA">Unsorted one-dimetional array</param>
        /// <returns>Sorted ascending one-dimension array </returns>
        public static int[] BubbleSortAsc(int[] arrA)
        {
            arrA = SortArray(arrA, true);

            return arrA;
        }

        /// <summary>
        /// Sort descending one-dimension array
        /// </summary>
        /// <param name="arrA">Unsorted one-dimetional array</param>
        /// <returns>Sorted descending one-dimension array </returns>
        public static int[] BubbleSortDesc(int[] arrA)
        {
            arrA = SortArray(arrA, false);

            return arrA;
        }

        private static int[] SortArray(int[] arrA, bool isAsc)
        {
            if (arrA is null)
                throw new ArgumentNullException("Array cannot be NULL");

            for (int i = 0; i < arrA.Length; i++)
            {
                for (int j = i + 1; j < arrA.Length; j++)
                {
                    if (isAsc)
                    {
                        if (arrA[j] < arrA[i])
                            RearrangeArrayElements(ref arrA[i], ref arrA[j]);
                    }
                    else
                    {
                        if (arrA[j] > arrA[i]) 
                            RearrangeArrayElements(ref arrA[i], ref arrA[j]);
                    }
                }
            }

            return arrA;
        }

        private static void RearrangeArrayElements(ref int x, ref int y)
        {
            var temp = x;
            x = y;
            y = temp;
        }
    }
}