using System;
using System.Text;

namespace CircularLinkedList
{
    public class CircularLinkedList<T>
    {
        private CircularLinkedListNode<T> _last;
        public int Count { get; private set; }

        public void AddFirst(T value)
        {
            var node = new CircularLinkedListNode<T>(value);

            if (IsEmpty())
            {
                _last = node;
                _last.Next = _last;
            }
            else
            {
                node.Next = _last.Next;
                _last.Next = node;
            }

            Count++;
        }

        public void AddLast(T value)
        {
            AddFirst(value);
            _last = _last.Next;
        }

        public T RemoveFirst()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            var nodeToBeRemoved = _last.Next;

            if (_last == _last.Next)
                _last = null;
            else
            {
                _last.Next = nodeToBeRemoved.Next;
                nodeToBeRemoved.Next = null;
            }

            Count--;
            return nodeToBeRemoved.Value;
        }

        public T RemoveLast()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            var nodeToBeRemoved = _last;
            var previousOfLastNode = _last;

            while (previousOfLastNode.Next != _last)
            {
                previousOfLastNode = previousOfLastNode.Next;
            }

            if (previousOfLastNode == _last)
                _last = null;
            else
            {
                previousOfLastNode.Next = _last.Next;
                _last = previousOfLastNode;
            }

            Count--;
            return nodeToBeRemoved.Value;
        }

        public T Remove(T value)
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            var nodeToBeRemoved = _last.Next;
            var previousNode = _last;

            for (var i = 0; i < Count && !nodeToBeRemoved.Value.Equals(value); i++)
            {
                previousNode = nodeToBeRemoved;
                nodeToBeRemoved = nodeToBeRemoved.Next;
            }

            if (!nodeToBeRemoved.Value.Equals(value)) 
                throw new InvalidOperationException();

            if (_last == _last.Next)
                _last = null;
            else
            {
                if (nodeToBeRemoved == _last)
                    _last = previousNode;
                previousNode.Next = previousNode.Next.Next;
            }

            nodeToBeRemoved.Next = null;
            Count--;
            return nodeToBeRemoved.Value;

        }

        public bool Contains(T value)
        {
            if (IsEmpty())
                return false;

            var temp = _last;
            while (temp.Next != _last && !temp.Value.Equals(value))
                temp = temp.Next;

            return temp.Value.Equals(value);
        }

        public T Peek() => _last.Next.Value;

        public T LastPeek() => _last.Value;

        public void Clear()
        {
            _last = null;
            Count = 0;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            if (IsEmpty())
                return result + "]";

            result.Append('[').Append(_last.Value);

            var current = _last.Next;
            while (current != _last)
            {
                result.Append(", ").Append(current.Value);
                current = current.Next;
            }
            return result + "]";
        }

        // Private Helper Methods
        private bool IsEmpty() => _last == null;
    }
}