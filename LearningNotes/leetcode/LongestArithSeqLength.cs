using LearningNotes.leetcode.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode
{
    /*
     * 
     * --Problem(MEDIUM):
     * 1027. Longest Arithmetic Sequence
     * Given an array A of integers, return the length of the longest arithmetic subsequence in A.
     * 
     *  Example 1:
     *  Input: [9,4,7,2,10]
        Output: 3
        Explanation: 
        The longest arithmetic subsequence is [4,7,10].

        Example 2:
        Input: [3,6,9,12]
        Output: 4
        Explanation: 
        The whole array is an arithmetic sequence with steps of length = 3.

        Thought:
        1. How do we know a sequence like 3, 6, 9 are arithmetic sequence?
        the trick is: 6 * 2 = 3 + 9
        basically, mid * 2 = prev + next

        2. What is the LLAP (Length of the Longest Arithmetic Progression) of a sequence of 2 numbers like
           1, 6?
           The answer is 2. 
           You may ask, how can two numbers form a sequence? 
           Well, they satisfy the definition. Their difference is 5, and there is only 1 difference occurance.

           Given this logic, if the given set has two or more elements, then the value of LLAP is at least 2. Since I
           can just pick 2 random numbers and call them a sequence.


     */
    public class LongestArithSeqLength
    {
        // The idea is to use sequence's difference as key in map to track the whole sequence
        public static int Solution(int[] A)
        {
            // difference to <Index of Element for this difference, count of sequence>
            var dp = new Dictionary<int, Dictionary<int, int>>(); 
            int max = 2;

            for (int i = 0; i < A.Length; i++)
            {
                for (int j = i + 1; j < A.Length; j++)
                {
                    int a = A[i], b = A[j];
                    if (!dp.ContainsKey(b - a))
                    {
                        dp[b - a] = new Dictionary<int, int>();
                    }

                    var diffMap = dp[b - a];

                    /* 
                     * Ex. 4, 7, 2, 10
                     * 4 is the first one
                     */
                    if (!diffMap.ContainsKey(i))
                    {
                        diffMap[i] = 1;
                    }

                    // j is the "next" one (7 to 4 or 10 to 7), so add 1 to sequence count
                    diffMap[j] = diffMap[i] + 1;

                    max = Math.Max(max, diffMap[j]);
                }
            }

            return max;
        }

        // ###################################### Solution 2
        // faster and less memory
        public static int Solution2(int[] A)
        {
            var len = A.Length;
            var dp = new int[len, len];
            var valueToIndex = GetValueToIndexMap(A); // 1. you will see its usage shortly
            int rst = 0;

            for (int i = 0; i < len - 1; i++)
            {
                for (int j = i + 1; j < len; j++)
                {
                    // See point 2: initially the sequence's length is 2, since there are 2 numbers
                    dp[i, j] = 2;

                    /*
                     * 1. Move from start to end (end to start also works)
                     * 
                     * Ex. For sequence 9 4 7 2 10
                     * i is 9 initially, we populate first row
                     * 
                     *      9   4   7   2   10
                     * 9        2   2   2   2
                     * 4
                     * 7
                     * 2
                     * 10
                     * 
                     * when we get to 7, 10, we check whether we can prepend any number to the sequence (4)
                     *      9   4   7   2   10
                     * 9        2   2   2   2
                     * 4            2   2   2
                     * 7                2   2 + 1
                     * 2
                     * 10
                     */
                    int prev = A[i] * 2 - A[j];

                    // 2. First, there needs to exist a "4"
                    if (valueToIndex.TryGetValue(prev, out List<int> indexList))
                    {
                        // 3. if there are multiple "4", pick the closest one to 7 (aka i)
                        // ex. "4 4 1 4 7 10", if we pick the first 4, we lose the sequence "1 4"
                        int k = GetClosetIndex(indexList, i);
                        if (k != -1)
                        {
                            // 4. (7, 10) is build upon (4, 7). If you think in terms of Single number, it won't make sense
                            dp[i, j] = dp[k, i] + 1;
                        }
                    }

                    rst = Math.Max(rst, dp[i, j]);
                }
            }

            return rst;
        }

        // Get the closest index from list which is less than upperBound
        public static int GetClosetIndex(List<int> indexList, int upperBound)
        {
            int i = 0;
            int index = -1;

            while (i < indexList.Count && indexList[i] < upperBound)
            {
                index = indexList[i];
                i++;
            }

            return index;
        }

        // Ex. 1, 4, 7, 7, 10, 7
        // There are three "7", index of three occurances will be recorded [2, 3, 5]
        public static Dictionary<int, List<int>> GetValueToIndexMap(int[] A)
        {
            var valueToIndex = new Dictionary<int, List<int>>();
            for (int i = 0; i < A.Length; i++)
            {
                if (!valueToIndex.ContainsKey(A[i]))
                {
                    valueToIndex[A[i]] = new List<int>();
                }
                valueToIndex[A[i]].Add(i);
            }

            return valueToIndex;
        }
    }
}
