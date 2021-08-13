using System;
using System.Collections.Generic;

namespace CircularLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var circularLinkedList = new CircularLinkedList<int>();
            circularLinkedList.AddLast(10);
            circularLinkedList.AddLast(20);
            circularLinkedList.AddLast(30);
            circularLinkedList.AddLast(40);
            Console.WriteLine(circularLinkedList.Remove(30));
            Console.WriteLine(circularLinkedList.ToString());
            Console.ReadLine();
        }
    }
}
