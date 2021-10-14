using System;

namespace FixedSizeQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new FixedSizeQueue<int>(5);
            Console.WriteLine(queue.IsEmpty());
            queue.EnQueue(10);
            queue.EnQueue(20);
            queue.EnQueue(30);
            Console.WriteLine(queue.DeQueue());
            Console.WriteLine(queue.IsEmpty());
            Console.WriteLine(queue.IsFull());
            Console.WriteLine(queue.Contains(10));
            Console.WriteLine(queue.GetFront());
            Console.WriteLine(queue.GetRear());
            Console.WriteLine(queue.ToString());
            Console.ReadLine();
        }
    }
}
