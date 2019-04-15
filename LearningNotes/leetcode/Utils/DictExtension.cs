using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNotes.leetcode.Utils
{

    // C# doesn't have what Java has getOrDefault() for Dict. Need to copy and paste this to leetcode Window
    // Difference between Java Hashmap vs C#'s Dictionary: https://stackoverflow.com/questions/1273139/c-sharp-java-hashmap-equivalent
    public static class DictExtension
    {
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
         TKey key,
         TValue defaultValue)
        {
            TValue value;
            return dictionary.TryGetValue(key, out value) ? value : defaultValue;
        }
    }
}
