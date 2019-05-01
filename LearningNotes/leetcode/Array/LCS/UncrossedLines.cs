using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode
{
    /*
     * 1035. Uncrossed Lines(medium)
     * 
     * Now, we may draw a straight line connecting two numbers A[i] and B[j] as long as A[i] == B[j], and the line we draw does not intersect any other connecting (non-horizontal) line.

    Return the maximum number of connecting lines we can draw in this way.

            1   4   2
            |     \
            1   2   4

        This question is EXACT the same as finding the "longest common subsequence" (LCS) in 2 arrays or 2 strings etc
        "abcdaf" and "acbcf"

                a   b   c   d   a   f
            0   0   0   0   0   0   0
        a   0   1   1   1   1   1   1
        c   0   1   1   2   2   2   2
        b   0   1   2   2   2   2   2
        c   0   1   2   3   3   3   3
        f

        if (input[i] == input[j])
            // if equal, add 1 character to both arrays
            t[i][j] = t[i - 1][j - 1] + 1;
        else
            t[i][j] = max(t[i - 1][j], t[i][j - 1])
     */
    class UncrossedLines
    {
        public int MaxUncrossedLines(int[] A, int[] B)
        {
            int m = A.Length;
            int n = B.Length;
            var dp = new int[m + 1, n + 1];

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (A[i - 1] == B[j - 1])
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    else
                        /*
                         *      a   b   c
                         *  a   1   1   1
                         *  c   1   1   2
                         *  x   1   1   ?
                         *  
                         *  At question mark, you won't be able to know whether to compare
                         *  ac vs. abc  or
                         *  acx vs. ab
                         *  that's why math.max()
                         */
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
            return dp[m, n];
        }
    }
}
