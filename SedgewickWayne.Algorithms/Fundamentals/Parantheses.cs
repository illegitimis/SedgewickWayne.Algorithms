// http://algs4.cs.princeton.edu/13stacks/Parentheses.java.html
// Checks to see if the parentheses are balanced.

namespace SedgewickWayne.Algorithms
{
    using System;
    using CharStack = SedgewickWayne.Algorithms.Stack<char>;

    public static class Parantheses
    {
        private const char LEFT_PARENTHESIS = '(';
        private const char RIGHT_PARENTHESIS = ')';

        private const char LEFT_BRACE = '{';
        private const char RIGHT_BRACE = '}';

        private const char LEFT_BRACKET = '[';
        private const char RIGHT_BRACKET = ']';

        const char LEFT_ANGLE = '<';
        const char RIGHT_ANGLE = '>';

        public static bool IsBalanced(String s)
        {
            var stack = new CharStack();

            foreach (char c in s)
            {
                switch (c)
                {
                    case LEFT_PARENTHESIS:
                    case LEFT_BRACE:
                    case LEFT_BRACKET:
                    case LEFT_ANGLE:
                    {
                        stack.push(c);
                    }
                    break;

                    case RIGHT_PARENTHESIS:
                    case RIGHT_BRACE:
                    case RIGHT_BRACKET:
                    case RIGHT_ANGLE:
                    {
                        if (stack.IsEmpty) return false;
                        char top = stack.pop();
                        if (top != pair(c)) return false;
                    }
                    break;
                }               
            }

            return stack.IsEmpty;
        }

        static char pair(char c)
        {
            switch (c)
            {
                case LEFT_PARENTHESIS: return RIGHT_PARENTHESIS;
                case LEFT_BRACE: return RIGHT_BRACE;
                case LEFT_BRACKET: return RIGHT_BRACKET;
                case LEFT_ANGLE: return RIGHT_ANGLE;                    

                case RIGHT_PARENTHESIS: return LEFT_PARENTHESIS;
                case RIGHT_BRACE: return LEFT_BRACE;
                case RIGHT_BRACKET: return LEFT_BRACKET;
                case RIGHT_ANGLE: return LEFT_ANGLE;
            }

            return default(char);
        }
    }
}
