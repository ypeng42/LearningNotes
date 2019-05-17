using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode.Array
{
    /*
     * 128. Longest Consecutive Sequence
     * 
     * Given an unsorted array of integers, find the length of the longest consecutive elements sequence.

        Your algorithm should run in O(n) complexity.

        Example:

        Input: [100, 4, 200, 1, 3, 2]
        Output: 4
        Explanation: The longest consecutive elements sequence is [1, 2, 3, 4]. Therefore its length is 4.
     */
    class LongestConsequtiveSequence
    {
        // normal union find is n*logn
        // update two ends is enough, remember everything is consecutive
        // ex. 1 2 3 4 5
        // if first encounter 4, then 3, then 2
        // 1 2 3 4 5
        //   3 2 3
        // 3 doesn't have updated data, but doesn't matter, 
        public int LongestConsecutive(int[] nums)
        {
            var valToCount = new Dictionary<int, int>();
            var res = 0;

            foreach (int num in nums)
            {
                if (!valToCount.ContainsKey(num))
                {
                    var leftCount = valToCount.TryGetValue(num - 1, out int left) ? left : 0;
                    var rightCount = valToCount.TryGetValue(num + 1, out int right) ? right : 0;
                    int sum = leftCount + rightCount + 1;

                    res = Math.Max(res, sum);
                    valToCount[num] = sum;
                    valToCount[num - leftCount] = sum;
                    valToCount[num + rightCount] = sum;
                }
                else
                {
                    continue;
                }
            }

            return res;
        }
    }
}
