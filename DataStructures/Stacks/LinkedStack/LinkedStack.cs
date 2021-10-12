using System;
using System.Text;

namespace LinkedStack
{
    public class LinkedStack<T>
    {
        private Element _top;
        private int _count;

        public LinkedStack()
        {
            _count = 0;
        }

        public bool IsEmpty() => _count == 0;
        public int Count() => _count;

        public bool Contains(T item)
        {
            for (var temp = _top; temp != null; temp = temp.Next)
            {
                if (temp.Data.Equals(item))
                    return true;
            }

            return false;
        }

        public void Push(T item)
        {
            if (_top == null)
                _top = new Element(item);

            else
            {
                var data = new Element(item);
                var temp = _top;

                while (temp.Next != null)
                    temp = temp.Next;

                temp.Next = data;
            }

            _count++;
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            var poppedItem = _top;
            var newTop = _top.Next;
            _top.Next = null;
            _top = newTop;
            _count--;
            return poppedItem.Data;
        }


        public void Clear()
        {
            _top = null;
            _count = 0;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            return _top.Data;
        }

        public override string ToString()
        {
            var stack = new StringBuilder("[");
            var temp = _top;

            while (temp != null)
            {
                if (temp.Next == null)
                    stack.Append(temp.Data);
                else
                    stack.Append(temp.Data).Append(", ");

                temp = temp.Next;
            }

            return stack + "]";
        }

        private class Element
        {
            public T Data;
            public Element Next;

            public Element(T data)
            {
                this.Data = data;
            }
        }
    }
}