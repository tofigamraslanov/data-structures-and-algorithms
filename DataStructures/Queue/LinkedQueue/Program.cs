using System;

namespace LinkedQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new LinkedQueue<int>();
            queue.EnQueue(10);
            queue.EnQueue(20);
            queue.EnQueue(30);
            queue.EnQueue(40);
            Console.WriteLine(queue.DeQueue());
            Console.WriteLine(queue.ToString());
            Console.ReadLine();
        }
    }
}
