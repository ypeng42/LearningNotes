using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode.Array.LCS
{
    /*
     * 583. Delete Operation for Two Strings(medium)
     */
    class DeleteOperationTwoString
    {
        public int MinDistance(string word1, string word2)
        {
            int m = word1.Length, n = word2.Length;
            var dp = new int[m + 1, n + 1];
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (word1[i - 1] == word2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    } else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            // word1 to common, then from common to word2
            return m - dp[m, n] + n - dp[m, n];
        }
    }
}
