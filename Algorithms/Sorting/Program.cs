using System;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] items = { 12, 5, 2, 82 };

            //BubbleSort<int>.BubbleSortAlgorithm(items);
            //SelectionSort<int>.SelectionSortAlgorithm(items);
            InsertionSort<int>.InsertionSortAlgorithm(items);

            foreach (var item in items)
                Console.Write(item + " ");

            Console.ReadLine();
        }
    }
}
