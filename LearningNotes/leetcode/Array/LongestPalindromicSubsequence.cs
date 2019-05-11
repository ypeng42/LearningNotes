using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode.Array
{
    /*
     * 516. Longest Palindromic Subsequence(medium)
     * 
     * Given a string s, find the longest palindromic subsequence's length in s. You may assume that the maximum length of s is 1000.

        Example 1:
        Input:

        "bbbab"
        Output:
        4

        One possible longest palindromic subsequence is "bbbb".
     */
    public class LongestPalindromicSubsequence
    {
        public int LongestPalindromeSubseq(string s)
        {
            var dp = new int[s.Length, s.Length];

            for (int end = 0; end < s.Length; end++)
            {
                dp[end, end] = 1;
                // start with close to start, and move away
                for (int start = end - 1; start >= 0; start--)
                {
                    if (s[start] == s[end])
                    {
                        dp[start, end] = dp[start + 1, end - 1] + 2;
                    } else
                    {
                        // don't whether it's abb or bba
                        dp[start, end] = Math.Max(dp[start + 1, end], dp[start, end - 1]);
                    }
                }
            }

            return dp[0, s.Length - 1];
        }
    }
}
