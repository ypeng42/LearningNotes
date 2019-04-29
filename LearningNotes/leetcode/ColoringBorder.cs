using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode
{
    /*
     * 1034. Coloring A Border(medium)
     * Given a 2-dimensional grid of integers, each value in the grid represents the color of the grid square at that location.

Two squares belong to the same connected component if and only if they have the same color and are next to each other in any of the 4 directions.

The border of a connected component is all the squares in the connected component that are either 4-directionally adjacent to a square not in the component, or on the boundary of the grid (the first or last row or column).

Given a square at location (r0, c0) in the grid and a color, color the border of the connected component of that square with the given color, and return the final grid.

        Input: grid = [[1,1],[1,2]], r0 = 0, c0 = 0, color = 3
        Output: [[3, 3], [3, 2]]

        [[1,1],[1,2]] represents 
         1, 1
         1, 2
     */
    class ColoringBorder
    {
        public int[][] ColorBorder(int[][] grid, int r0, int c0, int color)
        {
            int row = grid.Length, col = grid[0].Length;
            var queue = new Queue<int[]>();
            var border = new HashSet<int[]>();
            var directuions = new int[4, 2] { { 0, 1 }, { 1, 0 }, { -1, 0 }, { 0, -1 } }; // right, up, down, left
            var visited = new bool[row, col];
            visited[r0, c0] = true;

            queue.Enqueue(new int[] { r0, c0 });

            while (queue.Count > 0)
            {
                var cell = queue.Dequeue();
                r0 = cell[0];
                c0 = cell[1];

                for (int i = 0; i < directuions.GetLength(0); i++)
                {
                    // cell [r, c] is the adjacent cell of cell[r0, c0]
                    int r = r0 + directuions[i, 0], c = c0 + +directuions[i, 1];
                    if (r >= 0 && r < row && c >= 0 && c < col && grid[r][c] == grid[r0][c0]) // check whether cell belongs to component
                    {
                        // note: only cell within grid range will be added to queue, so index out of range won't happen
                        if (!visited[r, c])
                        {
                            queue.Enqueue(new int[] { r, c});
                            visited[r, c] = true;
                        }
                    }
                    else
                    {
                        /*
                         * if it's neighbor (r, c) is out of range it means (r0, c0) is on border of grid
                         * if it's neighbor (r, c) is different color, according to definition, (r0, c0) is the border of the component
                         */
                        border.Add(new int[] { r0, c0});
                    }
                }
            }

            foreach(var b in border)
            {
                grid[b[0]][b[1]] = color;
            }

            return grid;
        }

    }
}
