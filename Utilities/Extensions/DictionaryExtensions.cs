using System;
using System.Collections.Generic;
using System.Text;

namespace Joie.Extensions
{
    public static class DictionaryExtensions
    {
        public static Dictionary<TValue, TKey> Reverse<TKey, TValue>(this IDictionary<TKey, TValue> source)
        {
            var dictionary = new Dictionary<TValue, TKey>();
            foreach (var entry in source)
            {
                if (!dictionary.ContainsKey(entry.Value))
                    dictionary.Add(entry.Value, entry.Key);
            }
            return dictionary;
        }
        public static K KeyByValue<K, V>(this Dictionary<K, V> dict, V val)
        {
            K key = default;
            foreach (KeyValuePair<K, V> pair in dict)
            {
                if (EqualityComparer<V>.Default.Equals(pair.Value, val))
                {
                    //return pair.Key;
                    key = pair.Key;
                    break;
                }
            }
            //return null;
            return key;
        }
    }
}
