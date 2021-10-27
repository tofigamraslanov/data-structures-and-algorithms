using System;

namespace Sorting
{
    public class InsertionSort<T> where T : IComparable<T>
    {
        public static void InsertionSortAlgorithm(T[] items)
        {
            for (var i = 1; i < items.Length; i++)
            {
                var current = items[i];
                var j = i - 1;

                while (j >= 0 && current.CompareTo(items[j]) < 0)
                {
                    items[j + 1] = items[j];
                    j--;
                }

                items[j + 1] = current;
            }
        }
    }
}