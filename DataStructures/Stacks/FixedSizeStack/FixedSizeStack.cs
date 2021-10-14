using System;

namespace FixedSizeStack
{
    public class FixedSizeStack<T>
    {
        private readonly T[] _items;
        private const int DefaultCapacity = 4;

        public int Count { get; private set; }

        public FixedSizeStack() => _items = new T[DefaultCapacity];
        public FixedSizeStack(int capacity) => _items = new T[capacity];

        public void Push(T item)
        {
            if (Count == _items.Length)
                throw new StackOverflowException();

            _items[Count++] = item;
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            return _items[--Count];
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            return _items[Count - 1];
        }

        public bool IsEmpty() => Count == 0;

        public bool IsFull() => Count == _items.Length;

        public bool Contains(T item)
        {
            for (var i = 0; i < Count; i++)
                if (_items[i].Equals(item))
                    return true;

            return false;
        }

        public void Clear()
        {
            if (IsEmpty()) return;
            var count = Count;
            for (var i = 0; i < count; i++)
                Pop();
        }

        public T[] ToArray()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            var array = new T[Count];
            for (var i = 0; i < Count; i++)
                array[i] = _items[i];

            return array;
        }
    }
}