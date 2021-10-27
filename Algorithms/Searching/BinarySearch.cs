namespace Searching
{
    public class BinarySearch
    {
        public static int BinarySearchIterative(int[] items, int item)
        {
            var start = 0;
            var end = items.Length;
            while (start <= end)
            {
                var middle = start + (end - start) / 2;

                if (item < items[middle])
                    end = --middle;
                if (item > items[middle])
                    start = ++middle;
                else
                    return middle;
            }
            return -1;
        }

        public static int BinarySearchRecursive(int[] items, int item, int start, int end)
        {
            if (start > end)
                return -1;

            var middle = start + (end - start) / 2;
            if (item < items[middle])
                return BinarySearchRecursive(items, item, start, --middle);
            if (item > items[middle])
                return BinarySearchRecursive(items, item, ++middle, end);

            return middle;
        }
    }
}