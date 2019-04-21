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
            RecoverFromPreorder s = new RecoverFromPreorder();
            s.Solution("1-2--3--4-5--6--7");
        }

        public static void x(ref int a)
        {
            a = 4;
        }
    }
}
