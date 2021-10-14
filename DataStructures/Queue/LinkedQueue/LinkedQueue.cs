using System;
using System.Text;

namespace LinkedQueue
{
    public class LinkedQueue<T>
    {
        private class Node
        {
            public T Data;
            public Node Next;

            public Node(T data)
            {
                Data = data;
            }
        }

        private Node _front;
        private Node _rear;
        public int Count { get; private set; }

        public void EnQueue(T item)
        {
            var node = new Node(item);
            if (_rear == null)
                _front = _rear = node;
            else
            {
                _rear.Next = node;
                _rear = node;
            }

            Count++;
        }

        public T DeQueue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue is empty.");

            var data = _front.Data;
            _front = _front.Next;
            Count--;
            return data;
        }

        public bool IsEmpty() => Count == 0;

        public T Front() => _front.Data;

        public T Rear() => _rear.Data;

        public bool Contains(T item)
        {
            var temp = _front;
            while (temp != null)
            {
                if (temp.Data.Equals(item))
                    return true;
                temp = temp.Next;
            }

            return false;
        }

        public override string ToString()
        {
            if (_front == null)
                return "[]";

            var queueString = new StringBuilder("[");
            var temp = _front;

            while (temp.Next != null)
            {
                queueString.Append(temp.Data).Append(", ");
                temp = temp.Next;
            }

            queueString.Append(temp.Data).Append("]");
            return queueString.ToString();
        }
    }
}