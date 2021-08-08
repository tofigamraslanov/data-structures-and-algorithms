using System;

namespace FixedSizeStack
{
    class Program
    {
        static void Main(string[] args)
        {
            FixedSizeStack<int> stack = new FixedSizeStack<int>(5);
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            stack.Push(40);
            stack.Push(50);

            Console.ReadLine();
        }
    }
}