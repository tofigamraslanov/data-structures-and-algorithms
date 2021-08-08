using System;
using System.Collections.Generic;

namespace CircularLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var circularLinkedList = new CircularLinkedList<int>();
            circularLinkedList.AddFirst(10);
            circularLinkedList.AddFirst(20);

            Console.ReadLine();
        }
    }
}
