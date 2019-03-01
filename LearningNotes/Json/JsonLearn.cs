using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.Json
{
    class JsonLearn
    {
        public static void ReadJson()
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\yuqing\source\repos\LearningNotes\LearningNotes\Json\Json1.json");
            var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(text);

            Console.WriteLine(values);
        }
    }
}
