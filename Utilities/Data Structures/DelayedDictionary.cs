using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Joie.Structures
{
    /// <summary>
    /// Use to delay adding elements to and removing elements from a Dictionary until Collapse() is called.
    /// Use InternalDictionary to get the main list. 
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class DelayedDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private IDictionary<TKey,TValue> _T = new Dictionary<TKey, TValue>();
        public Dictionary<TKey, TValue> InternalDictionary => _T as Dictionary<TKey, TValue>;
        private IDictionary<TKey, TValue> _TToAdd = new Dictionary<TKey, TValue>();
        private IDictionary<TKey, TValue> _TToRemove = new Dictionary<TKey, TValue>();

        public TValue this[TKey key] { get => _T[key]; set => _T[key] = value; }

        public ICollection<TKey> Keys => _T.Keys;

        public ICollection<TValue> Values => _T.Values;

        public int Count => _T.Count;

        public bool IsReadOnly => false;//throw new NotImplementedException();

        public void Add(TKey key, TValue value) => _TToAdd.Add(key, value);

        public void Add(KeyValuePair<TKey, TValue> item) => _TToAdd.Add(item);

        public void Clear()
        {
            _T.Clear();
            _TToAdd.Clear();
            _TToRemove.Clear();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item) => _T.Contains(item);//_T.ContainsKey(item.Key) && _T.ContainsValue(item.Value);

        public bool ContainsKey(TKey key) => _T.ContainsKey(key);

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) => _T.CopyTo(array, arrayIndex);//_T.CopyTo
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => _T.GetEnumerator();
        //{
        //    throw new NotImplementedException();
        //}

        public bool Remove(TKey key)
        {
            //throw new NotImplementedException();

            if (_TToRemove.ContainsKey(key))
                return true;

            if (_TToAdd.ContainsKey(key))
                return _TToAdd.Remove(key);

            _TToRemove.Add(key, _T[key]);
            return true;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            //throw new NotImplementedException();

            if (_TToRemove.Contains(item))
                    return true;

            if (_TToAdd.Contains(item))
                return _TToAdd.Remove(item);

            _TToRemove.Add(item);
            return true;
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value) => _T.TryGetValue(key, out value);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Collapse()
        {
            if (_TToRemove.Count > 0)
            {
                foreach (var t in _TToRemove)
                    _T.Remove(t);
                _TToRemove.Clear();
            }

            if (_TToAdd.Count > 0)
            {
                foreach (var t in _TToAdd)
                    _T.Add(t);
                _TToAdd.Clear();
            }
        }

        public void MassRemove(IDictionary<TKey, TValue> removeDictionary)
        {
            foreach (var item in removeDictionary)
                Remove(item);
        }
    }
}
