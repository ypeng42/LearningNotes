using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode.SlidingWindow
{
    /*
     * 3. Longest Substring Without Repeating Characters(medium)
     * 
     * Given a string, find the length of the longest substring without repeating characters.

        Example 1:

        Input: "abcabcbb"
        Output: 3 
        Explanation: The answer is "abc", with the length of 3. 
     */
    public class LongestSubstringNoRepeatingChar
    {
        public int LengthOfLongestSubstring(string s)
        {
            var count = new int[128];
            int head = 0, tail = 0, max = 0, numRepeatChar = 0;

            while (head < s.Length)
            {
                if (count[s[head]] > 0) numRepeatChar++;

                count[s[head]]++;
                head++;

                // shrink window until it's valid
                while (numRepeatChar > 0) // when think about this, first think about window's condition check
                {
                    if (count[s[tail]] > 1) numRepeatChar--; // sometimes we may remove the only char. ex "a" in bbaccxyz

                    count[s[tail]]--;
                    tail++;
                }

                max = Math.Max(max, head - tail);
            }

            return max;
        }
    }
}
