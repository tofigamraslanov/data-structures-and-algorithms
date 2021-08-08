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

        public T Peek() => _last.Next.Value;

        public T LastPeek() => _last.Value;


        // Private Helper Methods
        private bool IsEmpty() => _last == null;
    }
}