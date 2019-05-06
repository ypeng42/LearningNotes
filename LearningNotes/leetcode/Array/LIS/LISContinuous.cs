using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode.Array.LIS
{
    /*
     * 674. Longest Continuous Increasing Subsequence(easy)
     * 
     * Input: [1,3,5,4,7]
        Output: 3
        Explanation: The longest continuous increasing subsequence is [1,3,5], its length is 3. 
        Even though [1,3,5,7] is also an increasing subsequence, it's not a continuous one where 5 and 7 are separated by 4. 
     */
    class LISContinuous
    {
        public int FindLengthOfLCIS(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            int max = 1;
            int localMax = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[i - 1])
                {
                    localMax++;
                    max = Math.Max(max, localMax);
                } else
                {
                    localMax = 1;
                }
            }

            return max;
        }
    }
}
