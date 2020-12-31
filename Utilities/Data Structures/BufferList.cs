using System;
using System.Collections.Generic;
using System.Text;

namespace Joie_Engine.Utilities.Data_Structures
{
    /// <summary>
    /// -- DO NOT USE --
    /// 
    /// Use to delay adding elements to and removing elements from a list until Collapse() is called.
    /// Use InternalList to get the main list. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    // UpdateDelayedList()
    public class BufferList<T>
    {
        private List<T> _T;// = new List<T>();
        public List<T> InternalList => _T;

        private List<T> _TToAdd = new List<T>();
        private List<T> _TToRemove = new List<T>();

        public BufferList() => _T = new List<T>();
        public BufferList(List<T> t) => _T = t;

        public int Count => _T.Count;
        public int AdditionQueueCount => _TToAdd.Count;
        public int RemovalQueueCount => _TToRemove.Count;
        public int PostCollapseCount => _T.Count + _TToAdd.Count - _TToRemove.Count;

        public T this[int index] => _T[index];

        public void Add(T t) => _TToAdd.Add(t);
        public void Remove(T t)
        {
            if (_TToRemove.Contains(t))
                return;

            if (_TToAdd.Contains(t))
                { _TToAdd.Remove(t); return; }

            _TToRemove.Add(t);
        }
        public void Empty()
        {
            _T.Clear();
            _TToAdd.Clear();
            _TToRemove.Clear();
        }

        public void Collapse()//UpdateDelayedList()
        {
            if (_TToRemove.Count > 0)
            {
                foreach (var t in _TToRemove)
                {
                    _T.Remove(t);
                }
                _TToRemove.Clear();
            }

            if (_TToAdd.Count > 0)
            {
                foreach (var t in _TToAdd)
                {
                    _T.Add(t);
                }

                _TToAdd.Clear();
            }
        }
    }
}
