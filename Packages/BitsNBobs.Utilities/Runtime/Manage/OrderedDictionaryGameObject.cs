using System.Collections;
using UnityEngine;

namespace BitsNBobs.Manage
{
    public class OrderedDictionaryGameObject : OrderedDictionaryManager<string, GameObject>
    {
        public void Enable()
        {
            Get().SetActive(true);
        }

        public void Disable()
        {
            foreach (var item in Values)
            {
                ((GameObject)item).SetActive(false);
            }
        }

        public override void Remove()
        {
            UnityEngine.Object.Destroy(Get());
            base.Remove();
        }

        public override void Next()
        {
            base.Next();
            Disable();
            Enable();
        }

        public override void Back()
        {
            base.Back();
            Disable();
            Enable();
        }

        public override void Set(int index)
        {
            base.Set(index);
            Disable();
            Enable();
        }
        
        public override void Set(string key)
        {
            base.Set(key);
            Disable();
            Enable();
        }
        
    }
}