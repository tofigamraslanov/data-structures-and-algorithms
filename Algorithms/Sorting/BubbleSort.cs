using System;

namespace Sorting
{
    public class BubbleSort<T> where T : IComparable<T>
    {
        public static void BubbleSortAlgorithm(T[] items)
        {
            var length = items.Length;
            while (length > 1)
            {
                for (var i = 0; i < length - 1; i++)
                {
                    if (items[i].CompareTo(items[i + 1]) <= 0) continue;
                    var temp = items[i];
                    items[i] = items[i + 1];
                    items[i + 1] = temp;
                }
                length--;
            }
        }
    }
}