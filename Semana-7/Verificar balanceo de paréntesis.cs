using System;
using System.Collections.Generic;

namespace Utilities
{
    public static class BalanceChecker
    {
        /// <summary>
        /// Verifica si una expresión matemática está balanceada en términos de paréntesis, corchetes y llaves.
        /// </summary>
        /// <param name="expression">La expresión matemática a verificar.</param>
        /// <returns>Verdadero si está balanceada, falso si no.</returns>
        public static bool IsBalanced(string expression)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char c in expression)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    stack.Push(c);
                }
                else if (c == ')' || c == '}' || c == ']')
                {
                    if (stack.Count == 0) return false;

                    char top = stack.Pop();
                    if ((c == ')' && top != '(') || (c == '}' && top != '{') || (c == ']' && top != '['))
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }
    }
}
