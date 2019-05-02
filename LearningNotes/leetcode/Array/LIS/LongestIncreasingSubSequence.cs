using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode.Array
{
    /*
     * 300. Longest Increasing Subsequence(medium)
     * 
     * Input: [10,9,2,5,3,7,101,18]
    Output: 4 
    Explanation: The longest increasing subsequence is [2,3,7,101], therefore the length is 4. 
     */
    class LongestIncreasingSubSequence
    {
        // DP O(N*N):  dp[i] refers to the LIS ending at index i
        public int LengthOfLIS(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;

            var len = nums.Length;
            var dp = new int[len];
            var max = 0;

            for (int endIndex = 0; endIndex < len; endIndex++)
            {
                dp[endIndex] = 1; // 10 3, at 3, it's still 1 number
                for (int i = 0; i < endIndex; i++)
                {
                    if (nums[i] < nums[endIndex])
                    {
                        //10 3 4 12 13 20
                        // at 20, previous nums[end] is 3 from (3, 4) compare that with (10, 12, 13) + 1
                        dp[endIndex] = Math.Max(dp[endIndex], dp[i] + 1);
                    }
                }
                max = Math.Max(max, dp[endIndex]);
            }

            return max;
        }

        /*
         * Binary search way, n*logn
         * 
         * The key to understand is
         * 10 7 2 5 8 3 7
         *
         * list is 2 5 8
         *
         * the next item is 3, it will replace 5 (first thing greater than it), the strike length keeps the same,
         * but by replacing 5, we lower the threshold for the strike to continue.
         * (instead of > 5, > 3 is enough)
         */
        public int LengthOfLIS2(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;

            var list = new List<int>();
            list.Add(nums[0]);

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > list[list.Count - 1])
                {
                    list.Add(nums[i]);
                } else
                {
                    var replaceIndex = BinarySearch(list, nums[i]);
                    list[replaceIndex] = nums[i]; 
                }
            }

            return list.Count;
        }

        public int BinarySearch(List<int> list, int target)
        {
            int start = 0;
            int end = list.Count - 1;
            while (start + 1 < end)
            {
                // there should be more than 2 things between start and end
                int mid = start + (end - start) / 2;
                if (list[mid] == target)
                {
                    return mid;
                }
                else if (list[mid] < target)
                {
                    start = mid;
                }
                else
                {
                    end = mid;
                }
            }
            return list[start] >= target ? start : end; // 2 things left at the end
        }
    }
}
