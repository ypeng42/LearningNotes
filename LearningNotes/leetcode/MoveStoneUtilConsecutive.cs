using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode
{
    /*
     * 1033. Moving Stones Until Consecutive(easy)
     * 
     * Three stones are on a number line at positions a, b, and c.

Each turn, you pick up a stone at an endpoint (ie., either the lowest or highest position stone), and move it to an unoccupied 
position between those endpoints.  Formally, let's say the stones are currently at positions x, y, z with x < y < z.  
You pick up the stone at either position x or position z, and move that stone to an integer position k, with x < k < z and k != y.

The game ends when you cannot make any more moves, ie. the stones are in consecutive positions.

When the game ends, what is the minimum and maximum number of moves that you could have made?  
Return the answer as an length 2 array: answer = [minimum_moves, maximum_moves]
     */
    class MoveStoneUtilConsecutive
    {
        public int[] NumMovesStones(int a, int b, int c)
        {
            int max = Math.Max(a, Math.Max(b, c));
            int min = Math.Min(a, Math.Min(b, c));
            int mid = a;
            var arr = new int[] { a, b, c };
            for (int i = 0; i < 3; i++)
            {
                if (arr[i] != max && arr[i] != min) mid = arr[i];
            }

            if (max - min <= 2) return new int[] { 0, 0 };

            var rst = new int[2];

            if (max - mid <= 2 || mid - min <= 2)
            {
                // if only distence between 1 pair less than 2
                // 3 5 100
                // then the min move is change 100 to 4
                rst[0] = 1;
            }
            else
            {
                // 3 100 200 -> 3 5 100 -> 3 4 5
                rst[0] = 2;
            }
            rst[1] = max - min - 2;
            return rst;
        }
    }
}
