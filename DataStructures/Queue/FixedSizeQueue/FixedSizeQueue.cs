using System;
using System.Linq;
using System.Text;

namespace FixedSizeQueue
{
    /// <summary>
    /// Implementation of Queue Data Structure using Circular Array
    /// </summary>
    /// <typeparam name="T">Type of an element</typeparam>
    public class FixedSizeQueue<T>
    {
        private const int Capacity = 16;
        private readonly int _capacity;
        private readonly object[] _items;
        private int _front;
        private int _rear;
        public int Count { get; private set; }

        /// <summary>
        /// Initializes capacity with default capacity(16)
        /// </summary>
        public FixedSizeQueue()
        {
            _items = new object[Capacity];
            _capacity = Capacity;
        }

        /// <summary>
        /// Initializes capacity with optional capacity
        /// </summary>
        /// <param name="capacity">optional capacity</param>
        public FixedSizeQueue(int capacity)
        {
            _items = new object[capacity];
            _capacity = capacity;
        }

        /// <summary>
        /// Enqueues new element to the Queue
        /// </summary>
        /// <param name="item">inserted item</param>
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

        /// <summary>
        /// Gets front(or first) element of the Queue
        /// </summary>
        /// <returns>front element</returns>
        public T GetFront() => GetElement(_front);

        /// <summary>
        /// Gets rear(or last) element of the Queue
        /// </summary>
        /// <returns>last element</returns>
        public T GetRear() => GetElement(_rear - 1);

        /// <summary>
        /// Defines emptiness of Queue
        /// </summary>
        /// <returns>true if Queue is empty, otherwise false</returns>
        public bool IsEmpty() => Count == 0;

        /// <summary>
        /// Defines fullness of Queue
        /// </summary>
        /// <returns>true if Queue is full, otherwise false</returns>
        public bool IsFull() => Count == _capacity;

        /// <summary>
        /// Checks whether Queue contains element or not
        /// </summary>
        /// <param name="item">item</param>
        /// <returns>true if Queue contains specified element, false otherwise</returns>
        public bool Contains(T item) => _items.Contains(item);

        /// <summary>
        /// String representation of Queue
        /// </summary>
        /// <returns>String representation of the Queue in the form [FirstElement, ..., LastElement]</returns>
        public override string ToString()
        {
            var queue = new StringBuilder("[");

            int i;
            for (i = 0; i < Count - 1; i++)
                queue.Append(_items[(_front + 1) % _capacity]).Append(", ");

            queue.Append(_items[(_front + i) % _capacity]).Append("]");
            return queue.ToString();
        }

        /// <summary>
        /// Gets elements by casting Object element to specific type
        /// </summary>
        /// <param name="index">index of an element in actual array</param>
        /// <returns>element with specific type</returns>
        private T GetElement(int index) => (T)_items[index];
    }
}