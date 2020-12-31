using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Joie.Structures
{
    /// <summary>
    /// Use to delay adding elements to and removing elements from a list until Collapse() is called.
    /// Use InternalList to get the main list. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DelayedList<T> : IList<T>
    {
        private IList<T> _T = new List<T>();
        public List<T> InternalList => _T as List<T>;
        private IList<T> _TToAdd = new List<T>();
        private IList<T> _TToRemove = new List<T>();

        public T this[int index] { get => _T[index]; set => _T[index] = value; }

        public int Count => _T.Count;

        public bool IsReadOnly => false;//throw new NotImplementedException();

        public void Add(T item) => _TToAdd.Add(item);

        public void Clear()
        {
            _T.Clear();
            _TToAdd.Clear();
            _TToRemove.Clear();
        }

        public bool Contains(T item) => _T.Contains(item);

        public void CopyTo(T[] array, int arrayIndex) => _T.CopyTo(array, arrayIndex);

        public IEnumerator<T> GetEnumerator() => _T.GetEnumerator();
        //{
        //    foreach (T t in _T)
        //        yield return t;
        //}

        public int IndexOf(T item) => _T.IndexOf(item);

        public void Insert(int index, T item) => _T.Insert(index, item);

        public bool Remove(T item)
        {
            if (_TToRemove.Contains(item))
                return true;

            if (_TToAdd.Contains(item))
                return _TToAdd.Remove(item);

            _TToRemove.Add(item);
            return true;
        }

        /// <summary>
        /// --- DO NOT USE ---
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index) => _T.RemoveAt(index);

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

        public void MassRemove(IList<T> removeList)
        {
            foreach (T item in removeList)
                Remove(item);
        }
    }
}
