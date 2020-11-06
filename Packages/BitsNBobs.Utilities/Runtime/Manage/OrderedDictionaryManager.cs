using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Unity.Collections;
using UnityEngine;

namespace BitsNBobs.Manage
{
    public class OrderedDictionaryManager<K, T> : OrderedDictionary, IListManager<T>
    {
        public int Index { get; set; }
        public event Action Accessed;
        public event Action ChangedState;

        public virtual void Remove()
        {
            Remove(this[Index]);
            Index = Math.Max(0, Math.Min(Index, this.Count - 1));
            Accessed?.Invoke();
            ChangedState?.Invoke();
        }

        public void Add(K key, T value)
        {
            base.Add(key, value);
        }

        public virtual void Next()
        {
            if (this.Count > 0)
            {
                Index = (Index + 1 + Count) % Count;
                Accessed?.Invoke();
                ChangedState?.Invoke();
            }
        }

        public virtual void Back()
        {
            Index = (Index - 1 + Count) % Count;
            if (Index < 0)
                Index = this.Count - 1;
            Accessed?.Invoke();
            ChangedState?.Invoke();
        }
        
        public virtual void Set(int index)
        {
            Index = Mathf.Clamp(index, 0, Count - 1);
            Accessed?.Invoke();
            ChangedState?.Invoke();
        }

        public virtual void Set(K key)
        {
            var keys = new K[Keys.Count];
            Keys.CopyTo(keys, 0);
            var index = keys.ToList().IndexOf(key);
            
            if (index == -1) 
                return;
            
            Index = index;
            Set(Index);
        }

        public T Get()
        {
            return Get(Index);
        }

        public K GetKey()
        {
            return GetKey(Index);
        }

        public K GetKey(int index)
        {
            var keys = new K[Keys.Count];
            Keys.CopyTo(keys, 0);
            return keys[index];
        }

        public T Get(int index)
        {
            var o = this[GetKey(index)];
            return (T)o;
        }

        public T Get(K key)
        {
            return (T) this[key];
        }

        public T Get(string key)
        {
            return (T) this[key];
        }

        public int Id()
        {
            return Index;
        }

        public IEnumerable<T> Gets()
        {
            return Enumerable.Range(0, Count).Select(Get);
        }
    }
}