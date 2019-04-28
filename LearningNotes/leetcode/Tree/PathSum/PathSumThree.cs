using LearningNotes.leetcode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode.Tree.PathSum
{
    /*
     * 437. Path Sum III(easy)
     * The path does not need to start or end at the root or a leaf, 
     * but it must go Downward (traveling only from parent nodes to child nodes).

        The tree has no more than 1,000 nodes and the values are in the range -1,000,000 to 1,000,000.

        Related to 560. Subarray Sum Equals K(medium)
     */
    class PathSumThree
    {
        public int PathSum(TreeNode root, int sum)
        {
            return Dfs(root, 0, sum, new Dictionary<int, int>());
        }

        private int Dfs(TreeNode node, int sum, int target, Dictionary<int, int> sumToOccurance)
        {
            if (node == null) return 0;
            int currSum = sum + node.val;
            int rst = 0;

            if (currSum == target) rst++; // either do this or init map[0] = 1

            if (sumToOccurance.TryGetValue(currSum - target, out int occurance)) rst += occurance;
            
            //update map
            sumToOccurance[currSum] = (sumToOccurance.TryGetValue(currSum, out int old) ? old : 0) + 1;

            rst += Dfs(node.left, currSum, target, sumToOccurance) + Dfs(node.right, currSum, target, sumToOccurance);
            sumToOccurance[currSum] = sumToOccurance[currSum] - 1; // backtrack

            return rst;
        }
    }
}
