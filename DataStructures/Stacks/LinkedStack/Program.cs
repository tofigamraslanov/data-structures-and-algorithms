using System;

namespace LinkedStack
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedStack<int> stack = new LinkedStack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            
            Console.WriteLine(stack.ToString());

            Console.ReadLine();
        }
    }
}
