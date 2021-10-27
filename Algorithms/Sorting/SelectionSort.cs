using System;

namespace Sorting
{
    public class SelectionSort<T> where T : IComparable<T>
    {
        public static void SelectionSortAlgorithm(T[] items)
        {
            var length = items.Length;

            for (var i = 0; i < length - 1; i++)
            {
                var minIndex = i;
                for (var j = i + 1; j < length; j++)
                {
                    if (items[j].CompareTo(items[minIndex]) < 0)
                        minIndex = j;
                }

                var temp = items[i];
                items[i] = items[minIndex];
                items[minIndex] = temp;
            }
        }
    }
}