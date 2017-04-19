// http://algs4.cs.princeton.edu/13stacks/Parentheses.java.html
// Checks to see if the parentheses are balanced.
// http://algs4.cs.princeton.edu/13stacks/Evaluate.java.html
// http://algs4.cs.princeton.edu/13stacks/EvaluateDeluxe.java.html
// Dijkstra's two-stack algorithm.

namespace SedgewickWayne.Algorithms
{
    using System;
    using CharStack = SedgewickWayne.Algorithms.Stack<char>;
    using StrStack = SedgewickWayne.Algorithms.Stack<string>;
    using DblStack = SedgewickWayne.Algorithms.Stack<double>;
    using System.Globalization;

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

        private const char OP_ADD = '+';
        private const char OP_SUB = '-';
        private const char OP_DIV = '/';
        private const char OP_MUL = '*';
        private const char OP_MOD = '%';

        /// <summary>
        /// check string expression is scope balanced
        /// </summary>
        /// <param name="s">expr</param>
        /// <returns>true if parentheses are balanced, false otherwise</returns>
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

                    default: break;
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

        /// <summary>
        /// Evaluates (fully parenthesized) arithmetic expressions using Dijkstra's two-stack algorithm.
        /// </summary>
        /// <param name="expr">fully parenthesized expr</param>
        /// <returns>double val</returns>
        public static double Evaluate (string expr)
        {
            var ops = new StrStack();
            var vals = new DblStack();

            string[] tokens = expr.Split(' ');
            foreach (string s in tokens)
            {
                if (s.Length == 1)
                {
                    char c = s[0];
                    switch (c)
                    {
                        case LEFT_PARENTHESIS:
                        case LEFT_BRACE:
                        case LEFT_BRACKET:
                            ; //no op
                            break;


                        case OP_ADD: 
                        case OP_MUL: 
                        case OP_SUB: 
                        case OP_DIV: 
                        case OP_MOD:
                            ops.push(s);
                            break;

                        case RIGHT_PARENTHESIS:
                        case RIGHT_BRACE:
                        case RIGHT_BRACKET:
                        {
                                string sop = ops.pop();
                                if (sop == "sqrt") vals.push(Math.Sqrt(vals.pop()));
                                else
                                {
                                    var v1 = vals.pop();
                                    var v2 = vals.pop();
                                    
                                    switch (sop[0])
                                    {
                                        case OP_ADD: vals.push(v2 + v1); break;
                                        case OP_MUL: vals.push(v2 * v1); break;
                                        case OP_SUB: vals.push(v2 - v1); break;
                                        case OP_DIV: vals.push(v2 / v1); break;
                                        case OP_MOD: vals.push(v2 % v1); break;
                                        default: break;
                                    }
                                }
                        }
                        break;

                        default:
                            if (Char.IsNumber(c)) vals.push(c - '0');
                            else throw new NotImplementedException(s);
                            break;
                    }
                }
                                                  
                else
                {
                    double d;
                    if (Double.TryParse(s, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out d )) vals.push(d);
                    else if (s == "sqrt") ops.push(s);
                    else throw new NotImplementedException(s);
                }                                        
                
            }

            return vals.pop();
        }

    }
}
