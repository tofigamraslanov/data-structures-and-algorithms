using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    public class StringReverser
    {
        private string _input;

        public StringReverser(string input)
        {
            _input = input;
        }
        public string Reverse()
        {
            if (_input == null)
                throw new InvalidOperationException();

            var stack = new Stack<char>();

            foreach (var ch in _input.ToCharArray())
            {
                stack.Push(ch);
            }

            var reversedWord = new StringBuilder();

            for (var i = 0; i < _input.Length; i++)
            {
                reversedWord.Append(stack.Pop());
            }

            return reversedWord.ToString();
        }
    }
}