
using System;
using System.Collections.Generic;
using System.Linq;

namespace LearningNotes.leetcode
{
    /*
     * 1029. Two City Scheduling(easy)
     * There are 2N people a company is planning to interview. The cost of flying the i-th person to city A is costs[i][0], 
     * and the cost of flying the i-th person to city B is costs[i][1].

Return the minimum cost to fly every person to a city such that exactly N people arrive in each city.
     */
    public class TwoCitySchedule
    {
        public int SimpleSolution(int[][] costs)
        {
            // Rank according to how much cheaper going to A instead of B
            // if it's good for A, it's bad for B, and vise versa
            // the top half is best for A (the worst half for B)
            // the bottom half is best for B (the worst half for A)
            System.Array.Sort(costs, Comparer<int[]>.Create((a, b) =>
            {
                return a[0] - a[1] - (b[0] - b[1]);
            }));

            int sum = 0;
            for (int i = 0; i < costs.Length; ++i)
            {
                // Since we rank for A, going to A first
                if (i < costs.Length / 2)
                {
                    sum += costs[i][0];
                }
                else
                {
                    sum += costs[i][1]; // the rest is optimized for B
                }
            }
            return sum;
        }

        // the idea is, each time you pick A or B, you can save money. ex. for (10, 200), if you pick A, you save 190
        // use saved money as key in pq, try save as much money as possible given the quota. If quota for 1 city is used up, fly to other city 
        public class InfoBag
        {
            public int x;
            public int y;
            public int saved;

            public InfoBag(int x, int y, int saved)
            {
                this.x = x;
                this.y = y;
                this.saved = saved;
            }
        }

        public int TwoCitySchedCost(int[][] costs)
        {
            var pq = new SortedList<InfoBag, int>(Comparer<InfoBag>.Create((a, b) => {
                if (a.saved == b.saved) return 1; // same key is not allowed so I have to do this stupidness!
                return b.saved - a.saved;
            }));

            for (int i = 0; i < costs.Length; i++)
            {
                int a = costs[i][0];
                int b = costs[i][1];
                pq.Add(new InfoBag(a, b, Math.Abs(a - b)), -1); // -1 is trash, have to put in there cause pq in c# is stupid
            }

            int cost = 0;
            int aCount = costs.Length / 2;
            int bCount = costs.Length / 2;

            while (pq.Count != 0)
            {
                InfoBag info = pq.First().Key;
                pq.RemoveAt(0);

                if (aCount == 0)
                {
                    cost += info.y;
                    bCount--;
                    continue;
                }

                if (bCount == 0)
                {
                    cost += info.x;
                    aCount--;
                    continue;
                }


                if (info.y > info.x && aCount > 0)
                {
                    cost += info.x;
                    aCount--;
                }
                else
                {
                    cost += info.y;
                    bCount--;
                }
            }

            return cost;
        }
    }
}
