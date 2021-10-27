namespace Searching
{
    public class LinearSearch<T>
    {
        public static int LinearSearchIterative(T[] items, T item)
        {
            for (var i = 0; i < items.Length; i++)
                if (items[i].Equals(item))
                    return i;

            return -1;
        }

        public static int LinearSearchRecursive(T[] items, T item, int position)
        {
            if (position == items.Length)
                return -1;
            if (items[position].Equals(item))
                return position;

            return LinearSearchRecursive(items, item, ++position);
        }
    }
}