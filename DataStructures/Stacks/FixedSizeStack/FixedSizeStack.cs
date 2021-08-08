using System;

namespace FixedSizeStack
{
    public class FixedSizeStack<T>
    {
        private readonly T[] _items;
        private int _count;
        private const int DefaultCapacity = 4;

        public int Count => _count;

        public FixedSizeStack() => _items = new T[DefaultCapacity];
        public FixedSizeStack(int capacity) => _items = new T[capacity];

        public void Push(T item)
        {
            if (_count == _items.Length)
                throw new StackOverflowException();

            _items[_count++] = item;
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            return _items[--_count];
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            return _items[_count - 1];
        }

        public bool IsEmpty() => _count == 0;

        public bool Contains(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_items[i].Equals(item))
                    return true;
            }

            return false;
        }

        public void Clear()
        {
            if (!IsEmpty())
            {
                int count = _count;
                for (int i = 0; i < count; i++)
                    Pop();
            }
        }

        public T[] ToArray()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            T[] array = new T[_count];
            for (int i = 0; i < _count; i++)
                array[i] = _items[i];

            return array;
        }
    }
}