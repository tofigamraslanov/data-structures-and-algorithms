using System;
using System.Text;

namespace DoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        private DoublyLinkedListNode<T> _first;
        private DoublyLinkedListNode<T> _last;
        public int Count { get; private set; }

        public void AddFirst(T value)
        {
            var node = new DoublyLinkedListNode<T>(value);

            if (IsEmpty())
                _first = _last = node;
            else
            {
                node.Next = _first;
                _first.Previous = node;
                _first = node;
            }

            Count++;
        }

        public void AddLast(T value)
        {
            var node = new DoublyLinkedListNode<T>(value);

            if (IsEmpty())
                _first = _last = node;
            else
            {
                node.Previous = _last;
                _last.Next = node;
                _last = node;
            }

            Count++;
        }

        public void Add(T value, int position)
        {
            if (position < 0 || position > Count)
                throw new IndexOutOfRangeException();

            var node = new DoublyLinkedListNode<T>(value);

            if (IsEmpty())
            {
                _first = _last = node;
                Count++;
                return;
            }

            if (position == 0)
            {
                AddFirst(value);
                return;
            }

            if (position == Count)
            {
                AddLast(value);
                return;
            }

            var temp = FindNode(position);
            node.Next = temp;
            node.Previous = temp.Previous;
            temp.Previous.Next = node;
            temp.Previous = node;

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
                _first = _first.Next;
                _first.Previous = null;
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
                _last = _last.Previous;
                _last.Next = null;
            }

            Count--;
        }

        public void Remove(int position)
        {
            if (IsEmpty())
                throw new InvalidOperationException("No Such Element");

            if (_first == _last)
            {
                _first = _last = null;
                Count--;
                return;
            }

            if (position == 0)
            {
                RemoveFirst();
                return;
            }
            if (position == Count - 1)
            {
                RemoveLast();
                return;
            }

            var temp = FindNode(position);
            temp.Previous.Next = temp.Next;
            temp.Next.Previous = temp.Previous;
            temp.Next = null;
            temp.Previous = null;

            Count--;
        }

        public int IndexOf(T value)
        {
            var current = _first;
            int position = 0;
            while (current != null)
            {
                if (current.Value.Equals(value))
                    return position;

                current = current.Next;
                position++;
            }

            return -1;
        }

        public T Find(int position)
        {
            if (position < 0 || position >= Count)
                throw new IndexOutOfRangeException();

            return FindNode(position).Value;
        }

        public T FindLast(int position)
        {
            if (position < 0 || position >= Count)
                throw new IndexOutOfRangeException();

            return FindNode(Count - position - 1).Value;
        }

        public void Set(int position, T data)
        {
            if (position < 0 || position >= Count)
                throw new IndexOutOfRangeException();

            var item = FindNode(position);
            item.Value = data;
        }

        public void Reverse()
        {
            if (IsEmpty())
                return;

            var currentNode = _first;
            DoublyLinkedListNode<T> temp;


            while (currentNode != null)
            {
                temp = currentNode.Next;
                currentNode.Next = currentNode.Previous;
                currentNode.Previous = temp;
                currentNode = currentNode.Previous;
            }

            temp = _first;
            _first = _last;
            _last = temp;
        }

        public DoublyLinkedList<T> Clone()
        {
            var clonedLinkedList = new DoublyLinkedList<T>();
            var current = _first;

            int position = 0;
            while (current != null)
            {
                clonedLinkedList.Add(current.Value, position);
                current = current.Next;
                position++;
            }

            return clonedLinkedList;
        }

        public void Clear()
        {
            _first = null;
            _last = null;
            Count = 0;
        }

        public bool Contains(T value) => IndexOf(value) != -1;

        public void Print()
        {
            Console.Write("[");
            Print(_last);
            Console.WriteLine("]");
        }

        public DoublyLinkedList<T> Merge(DoublyLinkedList<T> list)
        {
            var mergedList = Clone();

            if (list._first == null)
                return mergedList;

            if (_first == null)
            {
                mergedList = list.Clone();
                return mergedList;
            }

            var current = list._first;
            while (current != null)
            {
                mergedList.AddLast(current.Value);
                current = current.Next;
            }

            return mergedList;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            DoublyLinkedListNode<T> temp = null;

            if (_first != null)
            {
                result.Append("[").Append(_first.Value);
                temp = _first.Next;
            }

            while (temp != null)
            {
                result.Append(", ").Append(temp.Value);
                temp = temp.Next;
            }

            return result + "]";
        }

        // Private Helper Methods
        private bool IsEmpty() => _first == null;

        private DoublyLinkedListNode<T> FindNode(int position)
        {
            var center = Count / 2;
            DoublyLinkedListNode<T> searchedNode;

            if (position < center)
            {
                searchedNode = _first;
                for (int i = 0; i < position; i++)
                {
                    searchedNode = searchedNode.Next;
                }
            }
            else
            {
                searchedNode = _last;
                for (int i = Count - 1; i > position; i--)
                {
                    searchedNode = searchedNode.Previous;
                }
            }

            return searchedNode;
        }

        private void Print(DoublyLinkedListNode<T> last)
        {
            if (last == null)
                return;

            Print(last.Previous);
            Console.Write(last.Value + ", ");
        }
    }
}