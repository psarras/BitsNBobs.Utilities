using System;
using System.Collections.Generic;
using UnityEngine;

namespace BitsNBobs.Manage
{
    public interface IListManager<T>
    {
        int Index { get; set; }
        event Action Accessed;
        event Action ChangedState;

        void Remove();
        void Next();
        void Back();
        T Get();
        T Get(int index);
        int Id();
    }


    [Serializable]
    public class ListManager<T> : List<T>, IListManager<T>
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

        public virtual void Next()
        {
            if (this.Count > 0)
            {
                Index = (++Index) % this.Count;
                Accessed?.Invoke();
                ChangedState?.Invoke();
            }
        }

        public virtual void Back()
        {
            Index--;
            if (Index < 0)
                Index = this.Count - 1;
            Accessed?.Invoke();
            ChangedState?.Invoke();
        }

        public virtual T Get()
        {
            Accessed?.Invoke();
            if (Index >= 0 && Index < this.Count)
                return this[Index];
            else
                return default(T);
        }

        public virtual T Get(int index)
        {
            Accessed?.Invoke();
            if (index >= 0 && index < this.Count)
                return this[index];
            else
                return default(T);
        }

        public virtual int Id()
        {
            Accessed?.Invoke();
            return Index;
        }

        public virtual void Set(int index)
        {
            Index = Mathf.Clamp(index, 0, Count - 1);
            Accessed?.Invoke();
            ChangedState?.Invoke();
        }

        public virtual void SetLast()
        {
            Index = Count - 1;
            Accessed?.Invoke();
            ChangedState?.Invoke();
        }

        public virtual void Set(T item)
        {
            var index = IndexOf(item);
            Set(index);
            ChangedState?.Invoke();
        }
    }
}