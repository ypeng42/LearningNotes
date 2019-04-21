using LearningNotes.leetcode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode.Tree.LevelOrder
{
    // 199 (Medium). Binary Tree Right Side View
    class TreeRightSideView
    {
        // level order traversal, using BFS makes more sense
        public IList<int> RightSideView(TreeNode root)
        {
            var rst = new List<int>();

            if (root == null) return rst;
            var q = new Queue<TreeNode>();
            q.Enqueue(root);

            while (q.Count != 0)
            {
                int levelSize = q.Count;

                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode node = q.Dequeue();
                    if (node.right != null) q.Enqueue(node.right);
                    if (node.left != null) q.Enqueue(node.left);
                    if (i == 0)
                    {
                        rst.Add(node.val);
                    }
                }
            }

            return rst;
        }
    }
}
