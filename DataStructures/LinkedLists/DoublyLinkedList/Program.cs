using System;
using System.Collections.Generic;

namespace DoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new DoublyLinkedList<int>();
            list.AddLast(10);
            list.AddLast(20);
            list.AddLast(30);
            list.AddLast(40);
            Console.WriteLine(list.ToString());
            Console.ReadLine();
        }
    }
}
