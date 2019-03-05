using LearningNotes.GenUtils;
using LearningNotes.ps;
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
        public static void ReadJsonAsEnum()
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\yuqing\source\repos\LearningNotes\LearningNotes\Json\Json1.json");
            var enumDict = JsonConvert.DeserializeObject<Dictionary<string, JobEnum>>(text);
            foreach (KeyValuePair<string, JobEnum> kvp in enumDict)
            {
                Debug.WriteLine(string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value));
            }
        }

        public static void ReadJsonAndConvertEnum()
        {
            var enumDict = new Dictionary<string, JobEnum>();

            string text = System.IO.File.ReadAllText(@"C:\Users\yuqing\source\repos\LearningNotes\LearningNotes\Json\Json1.json");
            var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(text);

            foreach (var entry in values)
            {
                JobEnum job;

                // If parsing failed, by default it will use the enum with value 0, which could cause confusion. This is 
                // more clear
                if (Enum.TryParse(entry.Value, out job) )
                {
                    enumDict.Add(entry.Key, job);
                } else
                {
                    enumDict.Add(entry.Key, JobEnum.Waiter);
                }
            }

            foreach (KeyValuePair<string, JobEnum> kvp in enumDict)
            {
                //textBox3.Text += ("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                Debug.WriteLine(string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value));
            }
        }
    }
}
