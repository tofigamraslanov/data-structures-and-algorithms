using System;
using System.Linq;
using System.Text;

namespace FixedSizeQueue
{
    public class FixedSizeQueue<T>
    {
        private const int Capacity = 16;
        private readonly int _capacity;
        private readonly object[] _items;
        private int _front;
        private int _rear;
        public int Count { get; private set; }

        public FixedSizeQueue()
        {
            _items = new object[Capacity];
            _capacity = Capacity;
        }

        public FixedSizeQueue(int capacity)
        {
            _items = new object[capacity];
            _capacity = capacity;
        }

        public void EnQueue(T item)
        {
            if (_capacity == Count)
                throw new InvalidOperationException("Queue is full");

            _items[_rear++] = item;
            _rear %= _capacity;
            Count++;
        }

        public T DeQueue()
        {
            if (Count == 0)
                throw new InvalidOperationException("Queue is empty");

            var item = GetElement(_front % _capacity);
            _items[_front++] = null;
            _front %= _capacity;
            Count--;
            return item;
        }

        public T GetFront() => GetElement(_front);

        public T GetRear() => GetElement(_rear - 1);

        public bool IsEmpty() => Count == 0;

        public bool IsFull() => Count == _capacity;

        public bool Contains(T item) => _items.Contains(item);

        public override string ToString()
        {
            var queue = new StringBuilder("[");

            int i;
            for (i = 0; i < Count - 1; i++)
                queue.Append(_items[(_front + 1) % _capacity]).Append(", ");

            queue.Append(_items[(_front + i) % _capacity]).Append("]");
            return queue.ToString();
        }

        private T GetElement(int index) => (T)_items[index];
    }
}