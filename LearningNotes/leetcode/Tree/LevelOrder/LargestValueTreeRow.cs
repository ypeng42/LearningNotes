using LearningNotes.leetcode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode
{
    // 515. Find Largest Value in Each Tree Row    
    // Memorize how to use BFS and DFS to do level order traversal is very important!!
    class LargestValueTreeRow
    {
        public IList<int> LargestValues(TreeNode root)
        {
            var rst = new List<int>();

            if (root == null) return rst;
            var q = new Queue<TreeNode>();
            q.Enqueue(root);

            while (q.Count != 0)
            {
                // The key for doing level order in BFS is, remember, when we start the level, keep the count, when
                // count finishes, we are done for this level
                int size = q.Count;
                int lvlMax = Int32.MinValue;

                for (int i = 0; i < size; i++)
                {
                    var node = q.Dequeue();
                    if (node.left != null) q.Enqueue(node.left);
                    if (node.right != null) q.Enqueue(node.right);

                    lvlMax = Math.Max(lvlMax, node.val);
                }

                rst.Add(lvlMax);
            }

            return rst;
        }

        // ############################### DFS Level order traversal ############### 
        // Compare to BFS, this is not bad either. The key is pass "depth" to track level, and increase depth when go 1 level deeper 
        public IList<int> DFSSolution(TreeNode root)
        {
            var rst = new List<int>();
            Helper(root, 0, rst);
            return rst;
        }

        private void Helper(TreeNode root, int depth, List<int> rst)
        {
            if (root == null) return;

            if (rst.Count <= depth)
            {
                rst.Add(root.val);
            }

            rst[depth] = Math.Max(rst[depth], root.val);

            Helper(root.left, depth + 1, rst);
            Helper(root.right, depth + 1, rst);
        }
    }
}
