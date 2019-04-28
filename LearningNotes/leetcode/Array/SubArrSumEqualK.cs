using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode.Array
{
    /*
     * 560. Subarray Sum Equals K(medium)
     * 
     * The length of the array is in range [1, 20,000].
        The range of numbers in the array is [-1000, 1000] and the range of the integer k is [-1e7, 1e7].
     */
    class SubArrSumEqualK
    {
        public int SubarraySum(int[] nums, int target)
        {
            // calculate sums
            int sum = 0;
            var sums = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                sums[i] = sum; 
            }

            /* 1. the idea is sum(i, j) = sum(0, j) - sum(0, i)
             * target = sum(0, j) - sum(0, i)
             * sum(0, j) - target = sum(0, i)
             * 
             * => currSum - target = prevSum
             * 
             * ex. 1 -1 1 -1 3, target = 3
             * 
             * when we get to 3, direct hit once.
             * prevsum = 0, occured twice.
             * so total of 3 times
             * 
             * 2. This is a 3 step process:
             * (1) calculate current sum 
             * (2) check map for currSum - target
             * (3) update occurance for current sum in the map
             */
            var rst = 0;
            var sumToOccurance = new Dictionary<int, int>();
            foreach (int currSum in sums)
            {
                // the last element of currSum is the last element of the sub-array ("j" in explanantion above)
                if (currSum == target) rst += 1;

                if (sumToOccurance.TryGetValue(currSum - target, out int occurance))
                {
                    rst += occurance;
                }

                // AFTER we done with currSum, update it's occurance
                // Note: if the same sum re-appears, its occurance value will be updated
                sumToOccurance[currSum] = (sumToOccurance.TryGetValue(currSum, out int value) ? value : 0) + 1;
            }

            return rst;
        }
    }
}
