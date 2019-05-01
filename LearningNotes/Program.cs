using LearningNotes.Files;
using LearningNotes.Json;
using LearningNotes.leetcode;
using LearningNotes.leetcode.Array.LCS;
using LearningNotes.leetcode.Tree;
using LearningNotes.leetcode.Tree.BSTSearch;
using LearningNotes.leetcode.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new MaxLenRepeatedArray();
            s.FindLength(new int[] {1, 0, 1, 0, 1}, new int[] { 0, 1, 1, 1, 1 });
        }

        // That's the closest I can get
        public static void PQ()
        {
            var pq = new SortedList<int, int>(Comparer<int>.Create((x, y) => y - x));
            pq.Add(10, 10);
            pq.Add(20, 20);
            pq.Add(30, 30);

            Console.WriteLine(pq.First().Key);
            pq.RemoveAt(0);
            Console.WriteLine(pq.First().Key);
            pq.RemoveAt(0);
            Console.WriteLine(pq.First().Key);
            pq.RemoveAt(0);
        }

        public static void x(ref int a)
        {
            a = 4;
        }

        public static void MultiDimensionArrayLearn()
        {
            // Multi-dimension array
            int[,] a = new int[2, 1] { { 56 }, { 100 } };
            Console.WriteLine(a[0, 0]); //56 
            Console.WriteLine(a[1, 0]); //100

            //A jagged array is an array whose elements are arrays. The elements of a jagged array can be of different dimensions and sizes
            int[][] jaggedArray = new int[][]
            {
                new int[] { 56 },
                new int[] { 100 },
                new int[] { 11, 22 }
            };

            Console.WriteLine(jaggedArray[0][0]); //56 
            Console.WriteLine(jaggedArray[2][1]); //22

            //You can't create a MyClass[10][20] because each sub-array has to be initialized separately, as they are separate objects.

            // the difference between the two: https://stackoverflow.com/questions/4648914/why-we-have-both-jagged-array-and-multidimensional-array
        }
    }
}
