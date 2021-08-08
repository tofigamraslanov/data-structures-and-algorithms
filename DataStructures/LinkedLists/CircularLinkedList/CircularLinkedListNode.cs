namespace CircularLinkedList
{
    public class CircularLinkedListNode<T>
    {
        public T Value { get; set; }
        public CircularLinkedListNode<T> Next { get; set; }

        public CircularLinkedListNode(T value) => Value = value;
    }
}