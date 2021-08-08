using System;

namespace DynamicArray
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicArray numbers = new DynamicArray(3);
            numbers.Insert(10);
            numbers.Insert(20);
            numbers.Insert(30);

            //numbers.InsertAt(50,0);

            //numbers.RemoveAt(0);

            //Console.WriteLine(numbers.IndexOf(220));

            //Console.WriteLine(numbers.Max());

            var reversedNumbers = numbers.Reverse();
            foreach (var reversedNumber in reversedNumbers)
            {
                Console.WriteLine(reversedNumber);
            }

            //numbers.Print();

            Console.ReadLine();
        }
    }
}