using System;
using System.Collections.Generic;
using System.Linq;

namespace SinglyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new SinglyLinkedList<int>();
            list.AddLast(10);
            list.AddLast(20);
            list.AddLast(30);
            list.AddLast(40);
            list.AddFirst(5);
            list.AddFirst(15);
            list.Add(50, -1);
            list.Remove(10);
            list.Remove(20);
            var arrayList = list.ToArray();

            foreach (var i in arrayList)
            {
                Console.WriteLine(i);
            }

            list.PrintMiddle();

            Console.ReadLine();
        }
    }
}