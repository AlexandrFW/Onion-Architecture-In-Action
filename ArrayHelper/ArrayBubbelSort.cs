using System;
using System.Collections.Generic;

namespace ArrayHelper
{
    public static class ArrayBubbelSort
    {
        public static int[] BubbelSortAsc(int[] arrA)
        {
            arrA = SortArray(arrA, true);

            return arrA;
        }


        public static int[] BubbelSortDesc(int[] arrA)
        {
            arrA = SortArray(arrA, false);

            return arrA;
        }

        private static int[] SortArray(int[] arrA, bool isAsc)
        {
            for (int i = 0; i < arrA.Length; i++)
            {
                for (int j = i + 1; j < arrA.Length; j++)
                {
                    if (isAsc)
                    {
                        if (arrA[j] < arrA[i]) // Check if the next value is greater than the previous and change the place of each other
                        {
                            var temp = arrA[i];
                            arrA[i] = arrA[j];
                            arrA[j] = temp;
                        }
                    }
                    else
                    {
                        if (arrA[j] > arrA[i]) // Check if the next value is less than the previous and change the place of each other
                        {
                            var temp = arrA[i];
                            arrA[i] = arrA[j];
                            arrA[j] = temp;
                        }
                    }
                }
            }

            return arrA;
        }
    }
}