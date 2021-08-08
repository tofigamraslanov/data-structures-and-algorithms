using System;

namespace SinglyLinkedList
{
    public class SinglyLinkedList<T>
    {
        private SinglyLinkedListNode<T> _first;
        private SinglyLinkedListNode<T> _last;
        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var node = new SinglyLinkedListNode<T>(item);

            if (IsEmpty())
                _first = _last = node;
            else
            {
                node.Next = _first;
                _first = node;
            }

            Count++;
        }

        public void AddLast(T item)
        {
            var node = new SinglyLinkedListNode<T>(item);

            if (IsEmpty())
                _first = _last = node;
            else
            {
                _last.Next = node;
                _last = node;
            }

            Count++;
        }

        public void Add(T item, int position)
        {
            if (position < 0 || position > Count)
                throw new IndexOutOfRangeException();

            var node = new SinglyLinkedListNode<T>(item);

            if (IsEmpty())
                _first = _last = node;

            if (position == 0)
            {
                node.Next = _first;
                _first = node;
            }
            else
            {
                var current = _first;
                for (var i = 0; i < position - 1; i++)
                    current = current.Next;

                node.Next = current.Next;
                current.Next = node;
            }

            Count++;
        }

        public void RemoveFirst()
        {
            if (IsEmpty())
                throw new InvalidOperationException("No Such Element");

            if (_first == _last)
                _first = _last = null;
            else
            {
                var second = _first.Next;
                _first.Next = null;
                _first = second;
            }

            Count--;
        }

        public void RemoveLast()
        {
            if (IsEmpty())
                throw new InvalidOperationException("No Such Element");

            if (_first == _last)
                _first = _last = null;
            else
            {
                var previous = GetPrevious(_last);
                _last = previous;
                _last.Next = null;
            }

            Count--;
        }

        public void Remove(T item)
        {
            if (IsEmpty())
                throw new InvalidOperationException("No Such Element");

            if (_first == _last)
                _first = _last = null;
            else
            {
                var node = new SinglyLinkedListNode<T>(item);
                var current = _first;
                while (current != null)
                {
                    if (current.Value.Equals(node.Value))
                    {
                        var previous = GetPrevious(current);
                        if (previous == null)
                        {
                            RemoveFirst();
                            return;
                        }
                        previous.Next = current.Next;
                        current.Next = null;
                    }
                    current = current.Next;
                }
            }

            Count--;
        }

        public int IndexOf(T item)
        {
            int index = 0;
            var current = _first;

            while (current != null)
            {
                if (item.Equals(current.Value)) return index;
                current = current.Next;
                index++;
            }
            return -1;
        }

        public bool Contains(T item) => IndexOf(item) != -1;

        public T[] ToArray()
        {
            T[] array = new T[Count];
            var current = _first;
            int index = 0;

            while (current != null)
            {
                array[index++] = current.Value;
                current = current.Next;
            }

            return array;
        }

        public void Reverse()
        {
            if (IsEmpty()) return;

            var previous = _first;
            var current = previous.Next;
            while (current != null)
            {
                var next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }

            _last = _first;
            _last.Next = null;
            _first = previous;
        }

        public T GetKthFromTheEnd(int k)
        {
            if (IsEmpty())
                throw new InvalidOperationException();
            var previous = _first;
            var current = _first;

            for (int i = 0; i < k - 1; i++)
            {
                current = current.Next;
                if (current == null)
                    throw new ArgumentException();
            }

            while (current != _last)
            {
                previous = previous.Next;
                current = current.Next;
            }

            return previous.Value;
        }

        public void PrintMiddle()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            var previous = _first;
            var current = _first;

            while (current != _last && current.Next != _last)
            {
                previous = previous.Next;
                current = current.Next.Next;
            }

            if (current == _last)
                Console.WriteLine(previous.Value);
            else
                Console.WriteLine(previous.Value + ", " + previous.Next.Value);
        }

        public void Clear()
        {
            _first = null;
            Count = 0;

        }

        // Private Helper Methods
        private bool IsEmpty() => _first == null;

        private SinglyLinkedListNode<T> GetPrevious(SinglyLinkedListNode<T> singlyLinkedListNode)
        {
            var current = _first;

            while (current != null)
            {
                if (current.Next == singlyLinkedListNode) return current;
                current = current.Next;
            }

            return null;
        }
    }
}