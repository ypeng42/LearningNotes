using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode
{
    /*
     * 1036. Escape a Large Maze(hard)
     * In a 1 million by 1 million grid, the coordinates of each grid square are (x, y) with 0 <= x, y < 10^6.

We start at the source square and want to reach the target square.  Each move, we can walk to a 4-directionally adjacent square in the grid that isn't in the given list of blocked squares.

Return true if and only if it is possible to reach the target square through a sequence of moves.

        Note:
        0 <= blocked.length <= 200
        blocked[i].length == 2
        0 <= blocked[i][j] < 10^6
        source.length == target.length == 2
        0 <= source[i][j], target[i][j] < 10^6
        source != target

        it's so large simple BFS/DFS is not enough.
        Think it the other way, what's the largest area the blocked cell can have?
        the 200 blocked cell forms the hypotenuse (200 sqrt(2)), and the border forms 2 legs (200 each)
        the area is 200 * 200 * 0.5 = 20000

        so do a BFS, if we find 20000 cells it means we won't be surrounded by blocked cells, return true
     */
    public class EscapeLargeMaze
    {
        /*
         * class Solution(object):
            def isEscapePossible(self, blocked, source, target):
                blocked = {tuple(p) for p in blocked}

                def bfs(source, target):
                    bfs, seen = [source], {tuple(source)}
                    for x0, y0 in bfs:
                        for i, j in [[0, 1], [1, 0], [-1, 0], [0, -1]]:
                            x, y = x0 + i, y0 + j
                            if 0 <= x < 10**6 and 0 <= y < 10**6 and (x, y) not in seen and (x, y) not in blocked:
                                if [x, y] == target: return True
                                bfs.append([x, y])
                                seen.add((x, y))
                        if len(seen) > 20000: return True
                    return False
                return bfs(source, target) and bfs(target, source)

            Note: bfs is an array! it doesn't remove item from it!! so it's essentially the same as seen[] !!
         */
        HashSet<Tuple<int, int>> blockedSet = new HashSet<Tuple<int, int>>();
        public bool IsEscapePossible(int[][] blocked, int[] source, int[] target)
        {
            for (int i = 0; i < blocked.Length; i++)
                blockedSet.Add(Tuple.Create(blocked[i][0], blocked[i][1]));

            return Bfs(source, target) && Bfs(target, source); // Either target or source could be blocked!!
        }

        private bool Bfs(int[] source, int[] target)
        {
            var queue = new Queue<int[]>();
            var visited = new HashSet<Tuple<int, int>>();
            var directuions = new int[4, 2] { { 0, 1 }, { 1, 0 }, { -1, 0 }, { 0, -1 } };
            queue.Enqueue(source);
            while (queue.Count > 0)
            {
                int[] node = queue.Dequeue();
                int r = node[0];
                int c = node[1];

                for (int i = 0; i < 4; i++)
                {
                    int nr = r + directuions[i, 0];
                    int nc = c + directuions[i, 1];
                    if (CanMove(nr, nc, blockedSet, visited))
                    {
                        if (target[0] == nr && target[1] == nc) return true;
                        queue.Enqueue(new int[] { nr, nc });
                        visited.Add(Tuple.Create(nr, nc));
                    }
                }

                if (visited.Count > 20000)
                {
                    return true;
                }
            }

            return false;
        }

        private bool CanMove(int nr, int nc, HashSet<Tuple<int, int>> blockedSet, HashSet<Tuple<int, int>> visited)
        {
            return nr >= 0 && nr < Math.Pow(10, 6) && nc >= 0 && nc < Math.Pow(10, 6) && !blockedSet.Contains(Tuple.Create(nr, nc))
                && !visited.Contains(Tuple.Create(nr, nc));
        }
    }
}
