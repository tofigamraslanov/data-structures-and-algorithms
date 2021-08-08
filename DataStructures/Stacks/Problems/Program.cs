using System;

namespace Problems
{
    class Program
    {
        static void Main(string[] args)
        {
            Expression expression = new Expression();
            var result = expression.IsBalanced("(12 + 5)");
            Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}
