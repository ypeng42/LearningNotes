using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode.Array.LCS
{
    /*
     * 718. Maximum Length of Repeated Subarray(medium)
     * Input:
        A: [1,2,3,2,1]
        B: [3,2,1,4,7]
        Output: 3
        Explanation: 
        The repeated subarray with maximum length is [3, 2, 1].

        Really similar idea of LCS
        the difference is, if the number are different we don't care (leave it 0) since we want subarray
        not subsequence. For repeated subarray, +1 will be repeatly added when we check; we only care when strike
        happens to record the longest

        result:
            1   0   0   0   1
        1   1   0   0   0   1
        0   0   2   1   1   0
        0   0   1   3   2   0(strike break, no need to do anything)
        1   ...
        1
     */
    public class MaxLenRepeatedArray
    {
        public int FindLength(int[] a, int[] b)
        {
            int m = a.Length, n = b.Length;
            var dp = new int[m + 1, n + 1];
            int max = 0;
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (a[i - 1] == b[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                        max = Math.Max(max, dp[i, j]);
                    }
                }
            }
            return max;
        }
    }
}
