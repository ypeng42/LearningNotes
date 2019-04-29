using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode.Tree.Traversal
{
    class NaryPreorder
    {
        /*
         * 589. N-ary Tree Preorder Traversal(easy)
         */
        public IList<int> Preorder(Node root)
        {
            var rst = new List<int>();
            if (root == null) return rst;

            var stack = new Stack<Node>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                var node = stack.Pop();
                rst.Add(node.val);

                for (int i = node.children.Count - 1; i >= 0; i--)
                {
                    if (node.children[i] != null) stack.Push(node.children[i]);
                }
            }

            return rst;
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
}
