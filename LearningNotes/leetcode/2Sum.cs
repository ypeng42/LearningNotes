using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode
{
    public class _2Sum
    {
        public static int[] TwoSum(int[] nums, int target)
        {
            var rst = new int[2];
            var reminderToIndex = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (reminderToIndex.TryGetValue(nums[i], out int ind))
                {
                    rst = new int[] {i, ind};
                } else
                {
                    //reminderToIndex.Add(target - nums[i], i); // if add the same item twice it will throw exception;
                    reminderToIndex[target - nums[i]] = i; //use it like a hashmap
                }
            }

            return rst;
        }
    }
}
