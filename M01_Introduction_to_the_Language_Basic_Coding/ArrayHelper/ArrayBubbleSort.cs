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