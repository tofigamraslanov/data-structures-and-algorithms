using System;

namespace DynamicArray
{
    public class DynamicArray
    {
        private int[] _items;
        private int _count;

        public DynamicArray(int length)
        {
            _items = new int[length];
        }

        public void Insert(int item)
        {
            if (_count == _items.Length)
            {
                int[] temp = new int[2 * _count];
                for (int i = 0; i < _count; i++)
                    temp[i] = _items[i];

                _items = temp;
            }

            _items[_count++] = item;
        }


        public void InsertAt(int item, int index)
        {

        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
                throw new ArgumentException();

            for (int i = index; i < _count; i++)
            {
                if (i == _count - 1)
                {
                    int[] temp = new int[_count + 1];
                    for (int j = 0; j < _count; j++)
                        temp[j] = _items[j];

                    _items = temp;
                }
                _items[i] = _items[i + 1];
            }
            _count--;
        }

        public int IndexOf(int item)
        {
            for (int i = 0; i < _count; i++)
                if (_items[i] == item)
                    return i;

            return -1;
        }

        public int Max()
        {
            int max = _items[0];
            for (int i = 0; i < _count; i++)
                if (_items[i] > max)
                    max = _items[i];
            return max;
        }

        public int[] Reverse()
        {
            int[] temp = new int[_count];
            for (int i = 0; i < _count; i++)
                temp[i] = _items[_count - i - 1];
            return temp;
        }

        public void Print()
        {
            for (int i = 0; i < _count; i++)
            {
                Console.WriteLine(_items[i]);
            }
        }
    }
}