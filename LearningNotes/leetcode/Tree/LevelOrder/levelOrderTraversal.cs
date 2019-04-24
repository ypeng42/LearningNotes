using LearningNotes.leetcode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode.Tree.LevelOrder
{
    /*
     * 102. Binary Tree Level Order Traversal(medium)
     */
    class levelOrderTraversal
    {
        // Nothing fancy, I prefer BFS and can do this in my sleep....
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            var rst = new List<IList<int>>();

            if (root == null) return rst;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                int size = queue.Count;
                var levelList = new List<int>();
                for (int i = 0; i < size; i++)
                {
                    var node = queue.Dequeue();
                    levelList.Add(node.val);
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
                rst.Add(levelList);
            }

            return rst;
        }
    }
}
