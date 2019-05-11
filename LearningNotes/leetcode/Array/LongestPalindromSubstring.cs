using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode.Array
{
    /*
     * 5. Longest Palindromic Substring(medium)
     * 
     * Given a string s, find the longest palindromic substring in s. You may assume that the maximum length of s is 1000.

        Example 1:

        Input: "babad"
        Output: "bab"
        Note: "aba" is also a valid answer.
     */
    public class LongestPalindromSubstring
    {
        public string DP(string s)
        {
            if (s == null || s.Length < 2) return s;

            var dp = new bool[s.Length, s.Length];
            int startTracker = 0, endTracker = 0; 

            for (int end = 0; end < s.Length; end++)
            {
                for (int start = end; start >= 0; start--)
                {
                    dp[start, end] = s[start] == s[end] && (end - start < 2 || dp[start + 1, end - 1]);


                    if (dp[start, end] && end - start > endTracker - startTracker)
                    {
                        startTracker = start;
                        endTracker = end;
                    }
                }
            }

            return s.Substring(startTracker, endTracker - startTracker + 1);
        }

        public string LongestPalindrome(string s)
        {
            if (s == null || s.Length < 2) return s;

            int maxLen = 0, beginIndex = 0;

            //aabaa, max len will be found before mid point, maxLen / 2 can be skipped
            for (int i = 0; i < (s.Length - maxLen / 2); i++)
            {
                int left = i, right = i;

                while (left - 1 >= 0 && s[left - 1] == s[i]) left--;
                while (right + 1 < s.Length && s[right + 1] == s[i]) right++;

                while (right + 1 < s.Length && left - 1 >= 0 && s[right + 1] == s[left - 1])
                {
                    right++;
                    left--;
                }

                int newLen = right - left + 1;
                if (newLen > maxLen)
                {
                    maxLen = newLen;
                    beginIndex = left;
                }
            }

            return s.Substring(beginIndex, maxLen);
        }
    }
}
