using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace BitsNBobs.Manage
{
    public class GameObjectManager : ListManager<GameObject>
    {

        public void Enable()
        {
            this[Index].SetActive(true);
        }

        public void Disable()
        {
            foreach (var item in this)
            {
                item.SetActive(false);
            }
        }

        public override void Remove()
        {
            UnityEngine.Object.Destroy(this[Index]);
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

    }
}
