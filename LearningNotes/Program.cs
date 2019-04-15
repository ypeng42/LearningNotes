using LearningNotes.Files;
using LearningNotes.Json;
using LearningNotes.leetcode;
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
            //List<int> l = new List<int>();
            //l.Add(3);

            var valueToIndex = new Dictionary<int, List<int>>();
            Console.WriteLine(DivisorGame.Solution(123000));
        }
    }
}
