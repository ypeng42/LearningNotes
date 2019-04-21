using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode
{
    /*
     * 1030. Matrix Cells in Distance Order(easy)
     */
    class CellInDistanceOrder
    {
        // The idea is not hard, but it takes too long to type
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
