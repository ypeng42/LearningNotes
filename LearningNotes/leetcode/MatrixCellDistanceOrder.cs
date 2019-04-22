using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode
{
    /*
     * 1030. Matrix Cells in Distance Order(easy)
     * We are given a matrix with R rows and C columns has cells with integer coordinates (r, c), where 0 <= r < R and 0 <= c < C.

Additionally, we are given a cell in that matrix with coordinates (r0, c0).

Return the coordinates of all cells in the matrix, sorted by their distance from (r0, c0) from smallest distance to largest distance.  
Here, the distance between two cells (r1, c1) and (r2, c2) is the Manhattan distance, |r1 - r2| + |c1 - c2|.  
(You may return the answer in any order that satisfies this condition.)
     */
    class MatrixCellDistanceOrder
    {
        // This is very straightforward, if using sort is not considered cheating...
        public int[][] SimpleSolution(int R, int C, int r0, int c0)
        {
            var rst = new List<Tuple<int, int>>();
            for (int i = 0; i < R; i++)
            {
                for (int j = 0; j < C; j++)
                {
                    rst.Add(Tuple.Create(i, j));
                }
            }

            rst.Sort((t1, t2) => {
                return (Math.Abs(t1.Item1 - r0) + Math.Abs(t1.Item2 - c0)) - (Math.Abs(t2.Item1 - r0) + Math.Abs(t2.Item2 - c0)); // just implementing the rule
            });

            int[][] data = new int[R * C][]; // the returning type is annoying, otherwise solution could be much shorter
            for (int i = 0; i < rst.Count; i++)
            {
                data[i] = new int[2];
                data[i][0] = rst[i].Item1;
                data[i][1] = rst[i].Item2;
            }
            return data;
        }


        // Solution 2: feel like overkill... but it works
        // the idea is every time distance + 1 (move 1 cell) goes to another level, do a level order traversal
        public int[][] AllCellsDistOrder(int R, int C, int r0, int c0)
        {
            int total = R * C;
            var visited = new int[R, C];
            var count = 0;
            int[][] rst = new int[total][];

            var q = new Queue<Tuple<int, int>>();
            q.Enqueue(Tuple.Create(r0, c0));
            visited[r0, c0] = 1;

            while (q.Count != 0)
            {
                int size = q.Count;
                for (int i = 0; i < size; i++)
                {
                    var point = q.Dequeue();
                    var row = point.Item1;
                    var col = point.Item2;
                    AddToRst(rst, row, col, count);
                    count++;

                    int newRow, newCol;

                    // top
                    newRow = row + 1;
                    newCol = col;
                    if (IsValid(R, C, newRow, newCol, visited))
                    {
                        q.Enqueue(Tuple.Create(newRow, newCol));
                        visited[newRow, newCol] = 1;
                    }

                    // right
                    newRow = row;
                    newCol = col + 1;
                    if (IsValid(R, C, newRow, newCol, visited))
                    {
                        q.Enqueue(Tuple.Create(newRow, newCol));
                        visited[newRow, newCol] = 1;
                    }

                    // bottom
                    newRow = row - 1;
                    newCol = col;
                    if (IsValid(R, C, newRow, newCol, visited))
                    {
                        q.Enqueue(Tuple.Create(newRow, newCol));
                        visited[newRow, newCol] = 1;
                    }

                    // left
                    newRow = row;
                    newCol = col - 1;
                    if (IsValid(R, C, newRow, newCol, visited))
                    {
                        q.Enqueue(Tuple.Create(newRow, newCol));
                        visited[newRow, newCol] = 1;
                    }
                }
            }

            return rst;
        }

        private void AddToRst(int[][] rst, int newRow, int newCol, int count)
        {
            rst[count] = new int[2];
            rst[count][0] = newRow;
            rst[count][1] = newCol;
        }

        private bool IsValid(int rMax, int cMax, int r, int c, int[,] visited)
        {
            if (r >= rMax || c >= cMax || r < 0 || c < 0 || visited[r, c] != 0) return false;

            return true;
        }
    }
}
