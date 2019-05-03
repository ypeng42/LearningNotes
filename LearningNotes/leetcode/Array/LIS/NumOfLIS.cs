using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode.Array.LIS
{
    /*
     * 673. Number of Longest Increasing Subsequence(medium)
     * Input: [1,3,5,4,7]
    Output: 2
    Explanation: The two longest increasing subsequence are [1, 3, 4, 7] and [1, 3, 5, 7].

        Input: [2,2,2,2,2]
    Output: 5
    Explanation: The length of longest continuous increasing subsequence is 1, and there are 5 subsequences' length is 1, so output 5.
     */
    class NumOfLIS
    {
        public int FindNumberOfLIS(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;

            var cnt = new int[nums.Length]; // number of LIS at each index
            var len = new int[nums.Length]; // length of LIS at each index

            int maxLen = 0;
            int rst = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                len[i] = cnt[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    /*
                     * (100 101 102) 4 8 1 2 10
                     * if nums[j] > nums[i], treat that series as non-existing
                     */
                    if (nums[j] < nums[i]) // i can be appended to the series
                    {
                        if (len[j] + 1 == len[i])
                        {
                            /* 1 1 2 2 3 3
                             * when we are at 3, there are definitely more than 1 way to reach 3, need to record all
                             * Say we reach the second "2". there are more than 1 way to reach that 2, so += cnt[j] instead of +1
                             */
                            cnt[i] += cnt[j];
                        } else if (len[j] + 1 > len[i]) // a new local max length, start over
                        {
                            cnt[i] = cnt[j];
                        }
                        len[i] = Math.Max(len[i], len[j] + 1);
                    }
                }

                if (maxLen == len[i])
                {
                    rst += cnt[i];
                } else if (maxLen < len[i]) // a new global max, start over
                {
                    rst = cnt[i];
                    maxLen = len[i];
                }
            }

            return rst;
        }
    }
}
