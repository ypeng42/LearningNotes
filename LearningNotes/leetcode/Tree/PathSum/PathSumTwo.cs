using LearningNotes.leetcode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode.Tree.PathSum
{
    /*
     * 113. Path Sum II(medium)
     */
    public class PathSumTwo
    {
        public IList<IList<int>> PathSum(TreeNode root, int sum)
        {
            var rst = new List<IList<int>>();
            Helper(root, 0, sum, new List<int>(), rst);
            return rst;
        }

        // Idea: simple backtracking
        private void Helper(TreeNode node, int sum, int target, List<int> tracker, List<IList<int>> rst)
        {
            if (node == null) return;

            tracker.Add(node.val);
            if (node.left == null && node.right == null && node.val + sum == target)
            {
                rst.Add(new List<int>(tracker.ToArray()));
            }

            Helper(node.left, sum + node.val, target, tracker, rst);
            if (node.left != null) tracker.RemoveAt(tracker.Count - 1); // remove if there is stuff to be removed, don't forget

            Helper(node.right, sum + node.val, target, tracker, rst);
            if (node.right != null) tracker.RemoveAt(tracker.Count - 1);
        }
    }
}
