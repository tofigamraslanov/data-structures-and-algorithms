using System.Collections.Generic;

namespace Problems
{
    public class Expression
    {
        private readonly List<char> _rightBrackets = new() { ')', '>', ']', '}' };
        private readonly List<char> _leftBrackets = new() { '(', '<', '[', '{' };

        public bool IsBalanced(string input)
        {
            var stack = new Stack<char>();

            foreach (var ch in input.ToCharArray())
            {
                if (IsLeftBracket(ch))
                    stack.Push(ch);

                if (IsRightBracket(ch))
                {
                    if (stack.Count == 0) return false;

                    var top = stack.Pop();
                    if (!BracketsMatch(top, ch))
                        return false;
                }

            }

            return stack.Count == 0;
        }

        private bool BracketsMatch(char left, char right)
        {
            return _leftBrackets.IndexOf(left) == _rightBrackets.IndexOf(right);
        }

        private bool IsRightBracket(char ch)
        {
            return _rightBrackets.Contains(ch);
        }

        private bool IsLeftBracket(char ch)
        {
            return _leftBrackets.Contains(ch);
        }
    }
}