using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace BitsNBobs.Manage
{
    public class OrderedDictionaryGameObject : OrderedDictionaryManager<string, GoWrapper>
    {
        public virtual void Enable()
        {
            Get().SetActive(true);
        }

        public void Disable()
        {
            Get().SetActive(false);
        }

        public void DisableAll()
        {
            foreach (var item in Values)
            {
                ((GameObject)item).SetActive(false);
            }
        }

        public override void Remove()
        {
            UnityEngine.Object.Destroy(Get().GetGo());
            base.Remove();
        }

        public override void Next()
        {
            Disable();
            base.Next();
            Enable();
        }

        public override void Back()
        {
            Disable();
            base.Back();
            Enable();
        }

        public override void Set(int index)
        {
            Disable();
            base.Set(index);
            Enable();
        }
        
        public override void Set(string key)
        {
            Disable();
            base.Set(key);
            Enable();
        }

        public override void Clear()
        {
            GameObject.Destroy(Get().GetGo());
            base.Clear();
        }
        
    }
}