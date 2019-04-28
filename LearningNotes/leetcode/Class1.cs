using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode
{
    class Class1
    {
        

        public bool IsEscapePossible(int[][] blocked, int[] source, int[] target)
        {
            var queue = new Queue<int[]>();
            queue.Enqueue(source);
            int tr = target[1];
            int tc = target[0];

            while (queue.Count > 0)
            {
                int[] node = queue.Dequeue();
                int r = node[1];
                int c = node[0];

                if (tr == r && tc == c) return true;

                if (IsLegal(r + 1, c, blocked)) queue.Enqueue(new int[] { c, r + 1 });
                if (IsLegal(r, c + 1, blocked)) queue.Enqueue(new int[] { c + 1, r});
                if (IsLegal(r - 1, c, blocked)) queue.Enqueue(new int[] { c, r - 1 });
                if (IsLegal(r, c - 1, blocked)) queue.Enqueue(new int[] { c - 1, r });
            }

            return false;
        }

        private bool IsLegal(int r, int c, int[][] blocked)
        {
            if (!(r >= 0 && r <= 1000000 && c >= 0 && c <= 1000000)) return false;

            foreach(int[] block in blocked)
            {
                if (block[0] == c && block[1] == r) return false;
            }

            return true;
        }
    }
}
