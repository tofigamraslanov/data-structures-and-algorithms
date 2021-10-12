using System;

namespace DynamicStack
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicStack<int> stack = new DynamicStack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            stack.Push(40);
            stack.Push(50);
            stack.Pop();
            Console.WriteLine(stack.ToString());
            Console.ReadLine();
        }
    }
}
