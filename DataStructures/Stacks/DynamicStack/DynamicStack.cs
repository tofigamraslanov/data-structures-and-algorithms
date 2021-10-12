using System;
using System.Linq;
using System.Text;

namespace DynamicStack
{
    public class DynamicStack<T>
    {
        private static readonly int CAPACITY = 10;
        private int _capacity;
        private int _top;
        private object[] _items;

        public DynamicStack()
        {
            _capacity = CAPACITY;
            _items = new object[_capacity];
            _top = -1;
        }

        public int Count() => _top + 1;
        public bool IsEmpty() => _top < 1;
        public bool IsFull() => _top == _items.Length - 1;
        public bool Contains(T item) => _items.Contains(item);


        public void Push(T item)
        {
            if (Count() == _capacity)
                Expand();

            _items[++_top] = item;
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            var removedItem = GetElement(_top);
            _items[_top--] = null;

            if (Count() == _capacity / 2 && _capacity > CAPACITY)
                Shrink();

            return removedItem;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            return GetElement(_top);
        }

        public void Clear()
        {
            if (IsEmpty()) return;

            for (var i = 0; i < Count(); i++)
                Pop();

        }

        public override string ToString()
        {
            if (IsEmpty())
                return "[]";

            var stack = new StringBuilder("[");
            for (var i = 0; i < _top; i++)
                stack.Append(GetElement(i)).Append(", ");

            stack.Append(GetElement(_top)).Append("]");
            return stack.ToString();
        }

        // Private Helper Methods
        private T GetElement(int index) => (T)_items[index];
        private void Copy(object[] source, int capacity)
        {
            var destination = new object[capacity];
            Array.Copy(source, 0, destination, 0, Count());
            _items = destination;
        }

        private void Expand()
        {
            _capacity *= 2;
            Copy(_items, _capacity);
        }

        private void Shrink()
        {
            _capacity /= 2;
            Copy(_items, _capacity);
        }
    }
}