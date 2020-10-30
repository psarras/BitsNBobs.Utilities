using System;
using NavigationExperiment.Utilities;
using UnityEngine;

namespace BitsNBobs.Events
{
    public class OnClickEitherKeysUp : MonoClick
    {
        [SerializeField] private KeyCode[] keyCodes;
        public event Action KeyUp;

        private void Update()
        {
            foreach (var keyCode in keyCodes)
            {
                if (Input.GetKeyUp(keyCode))
                {
                    KeyUp?.Invoke();
                    Click();
                    return;
                }
            }
        }
    }

    [Serializable]
    public struct KeyGroup
    {
        public string name;
        public KeyCode[] keyCodes;
    }
}