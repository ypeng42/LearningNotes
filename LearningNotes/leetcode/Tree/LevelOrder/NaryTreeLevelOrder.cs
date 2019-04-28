using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode.Tree.LevelOrder
{
    /*
     * 429. N-ary Tree Level Order Traversal(easy)
     */
    class NaryTreeLevelOrder
    {
        public IList<IList<int>> LevelOrder(Node root)
        {
            var rst = new List<IList<int>>();
            if (root == null) return rst;

            var queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int size = queue.Count;
                var levelList = new List<int>();
                for (int i = 0; i < size; i++)
                {
                    var node = queue.Dequeue();
                    levelList.Add(node.val);
                    foreach (Node child in node.children)
                    {
                        if (child != null) queue.Enqueue(child);
                    }
                }

                rst.Add(levelList);
            }
            return rst;
        }
    }

    public class Node
    {
        public int val;
        public IList<Node> children;

        public Node() { }
        public Node(int _val, IList<Node> _children)
        {
            val = _val;
            children = _children;
        }
    }
}
