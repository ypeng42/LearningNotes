using System.Collections;
using System.Collections.Generic;

namespace LearningNotes.leetcode
{
    class ValidParenthese
    {
        /*
         * Note:
         * 1. Peek an empty stack will throw exception. Use Count property to avoid that
         * 2. s[0] to get char at index
         * 3. stack.Count == 0 to check IsEmpty
         * 
         * Thought process:
         * Use a stack, push for opening, pop for closing.
         */
        public bool IsValid(string s)
        {
            var stack = new Stack();

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];

                if (c == '{' || c == '[' || c == '(')
                {
                    stack.Push(c);
                }
                else
                {
                    if (stack.Count == 0) return false;
                    if (c == '}' && !stack.Pop().Equals('{')) return false;
                    if (c == ']' && !stack.Pop().Equals('[')) return false;
                    if (c == ')' && !stack.Pop().Equals('(')) return false;
                }
            }

            return stack.Count == 0;
        }
    }
}
