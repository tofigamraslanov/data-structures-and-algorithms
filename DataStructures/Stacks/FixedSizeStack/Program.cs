using System;
using System.Collections.Generic;

namespace FixedSizeStack
{
    class Program
    {
        static void Main(string[] args)
        {
            FixedSizeStack<int> stack = new FixedSizeStack<int>(5);
            stack.Push(10);
            stack.Push(30);
            stack.Push(40);
            stack.Push(50);
            Console.WriteLine(stack.IsFull());


            var stack2 = new Stack<int>(2);
            Console.ReadLine();
        }
    }
}