using System;

namespace Searching
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intItems = { 4, 5, 12, 24, 31, 54 };
            var intItem = 31;

            char[] charItems = { 'a', 'b', 'f' };
            var charItem = 'b';

            var resultLinearSearchIterative = LinearSearch<char>.LinearSearchIterative(charItems, charItem);
            var resultLinearSearchRecursive = LinearSearch<char>.LinearSearchRecursive(charItems, charItem, 0);

            var resultBinarySearchIterative = BinarySearch.BinarySearchIterative(intItems, intItem);
            var resultBinarySearchRecursive = BinarySearch.BinarySearchRecursive(intItems, intItem, 0, 6);

            Console.WriteLine(resultBinarySearchRecursive);
            Console.ReadLine();
        }
    }
}
