using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode.SlidingWindow
{
    /*
     * 395. Longest Substring with At Least K Repeating Characters(medium)
     * 
     * Find the length of the longest substring T of a given string (consists of lowercase letters only) such that 
     * every character in T appears no less than k times.
     * 
     * ex.
     * Input:
        s = "aaabb", k = 3

        Output:
        3

        The longest substring is "aaa", as 'a' is repeated 3 times.
     */
    public class LongestSubstringKRepeatingChar
    {
        /*
         * The most difficult part to apply two-pointer technique is to decide when to shrink the left side of window.

        To apply sliding window, we need to put some constraint on the sub-string within the window -> the number of unique characters within the window.

        And we also need an outer loop to explore every possible cases -> 26 characters

        For each uniqueChar constraint, we are going to use sliding window to find the "longest window which contains exactly x unique characters and for each character, 
        there are at least K repeating ones"

        For sliding window, if the constraint is not met, move the tail to shrink the window 
         */
        public int LongestSubstring(string s, int k)
        {
            int max = 0;
            // uniqueChar is the number of unique char in sliding window
            for (int uniqueChar = 1; uniqueChar <= 26; uniqueChar++)
            {
                var charCount = new int[26];

                int head = 0, tail = 0, uniqueCharCount = 0, numCharNoLessK = 0;

                while (head < s.Length)
                {
                    // sliding window should have only 1 condition
                    if (uniqueCharCount <= uniqueChar) // "less and equal" is important. When meets the condition, keep exploring instead of removing from window
                    {
                        int charIndex = s[head] - 'a';
                        // add the curr char to sliding window, update corresponding counter
                        if (charCount[charIndex] == 0) uniqueCharCount++;
                        charCount[charIndex]++;
                        if (charCount[charIndex] == k) numCharNoLessK++;

                        head++;
                    }
                    else
                    {
                        int charIndex = s[tail] - 'a'; // tail here, not head!!
                        // remove the curr char from sliding window, update corresponding counter
                        if (charCount[charIndex] == k) numCharNoLessK--;
                        charCount[charIndex]--;
                        if (charCount[charIndex] == 0) uniqueCharCount--;

                        tail++;
                    }

                    // uniqueCharCount == numCharNoLessK means all char in window appear at least k times
                    if (uniqueCharCount == uniqueChar && uniqueCharCount == numCharNoLessK) max = Math.Max(max, head - tail);
                }
            }

            return max;
        }

        // Divide and Conquer
        public int LongestSubstring2(String s, int k)
        {
            if (s == null || s.Length == 0 || k == 0) return 0;
            int[] count = new int[26];
            int res = 0;
            for (int i = 0; i < s.Length; i++)
            {
                count[s[i] - 'a']++;
            }
            List<int> pos = new List<int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (count[s[i] - 'a'] < k) pos.Add(i);
            }
            if (pos.Count == 0) return s.Length;

            pos.Insert(0, -1);
            pos.Add(s.Length);
            for (int i = 1; i < pos.Count; i++)
            {
                int start = pos[i - 1] + 1;
                int end = pos[i];
                int next = LongestSubstring2(s.Substring(start, end - start + 1), k); // end - start -> don't include dividing point
                res = Math.Max(res, next);
            }
            return res;
        }
    }
}
