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
     * The path does not need to start or end at the root or a leaf, but it must go downwards (traveling only from parent nodes to child nodes).

        The tree has no more than 1,000 nodes and the values are in the range -1,000,000 to 1,000,000.
     */
    class PathSumThree
    {
        private int rst = 0;
        private int target = 0;
        public int PathSum(TreeNode root, int sum)
        {
            target = sum;
            Dfs(root, 0, sum);
        }

        private int Dfs(TreeNode node, int sum, int target)
        {
            if (node == null) return 0;

            if (sum + node.val == target) rst++;

            int left = Dfs(node.left);
            int right = Dfs(node.right);
        }
    }
}
