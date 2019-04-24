using LearningNotes.leetcode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode.Tree.LevelOrder
{
    /*
     * 103. Binary Tree Zigzag Level Order Traversal(medium)
     */
    class ZigZagTraversal
    {
        // 90% same as level order, use a stack to achieve zig-zag
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            var rst = new List<IList<int>>();

            if (root == null) return rst;

            var toggle = true;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                int size = queue.Count;
                var levelList = new List<int>();
                var stack = new Stack<int>();

                for (int i = 0; i < size; i++)
                {
                    var node = queue.Dequeue();
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);

                    if (toggle)
                    {
                        levelList.Add(node.val);
                    } else
                    {
                        stack.Push(node.val);
                    }
                }

                if (!toggle)
                {
                    // Becareful about using for loop with stack count, as you poping, the count is changing!
                    while (stack.Count > 0) levelList.Add(stack.Pop());
                }

                toggle = !toggle;
                rst.Add(levelList);
            }

            return rst;
        }
    }
}
