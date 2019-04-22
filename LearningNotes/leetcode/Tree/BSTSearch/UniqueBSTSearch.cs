using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode.Tree.BSTSearch
{
    /*
     * 96. Unique Binary Search Trees(medium)
     */
    class UniqueBSTSearch
    {
        /*
         * 1.
         * For n, the total number of tree = sum of
         * trees when 1 is root
         * trees when 2 is root
         * trees when 3 is root
         * ...
         * 
         * 2.
         * ex. n = 5
         * when 3 is root. 2 subtree will be [1, 2] and [4, 5]
         * they are essentially the SAME, both are 2 consecutive numbers. The numbers are different but we don't care!
         * the total number of tree is the Multiply of the 2
         * 
         * 3.
         * Cache the result to improve performance
         * Therefore there are 2 solutions: bottom up and recursion with memorization
         */
        public int BottomUpSolution(int n)
        {
            int[] dp = new int[n + 1];
            dp[0] = 1; // since we always multiply, smart move!
            dp[1] = 1;
            for (int root = 2; root <= n; root++)
            {
                // in the outer loop, dp[3] will use result from dp[2], so we calculate each dp[] 1 by 1
                for (int j = 1; j <= root; j++)
                {
                    // inner loop calculates dp[n]
                    // we are adding up the number of tree when each node is root
                    // in the process, we will utilize previously cached result
                    dp[root] += dp[j - 1] * dp[root - j];
                }
            }
            return dp[n];
        }

        // ###################### recursion with memorization #############################
        public Dictionary<int, int> memo = new Dictionary<int, int>();
        public int NumTrees(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;

            if (memo.TryGetValue(n, out int rst)) return rst;

            int numOfTree = 0;
            for (int i = 1; i <= n; i++)
            {
                int left = NumTrees(i - 1);
                int right = NumTrees(n - i);

                if (left > 0 && right > 0)
                {
                    numOfTree += left * right;
                } else
                {
                    numOfTree += left + right;
                }
            }
            memo.Add(n, numOfTree);

            return numOfTree;
        }
    }
}
