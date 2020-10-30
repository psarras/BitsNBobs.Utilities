using System;
using NavigationExperiment.Utilities;
using UnityEngine;

namespace BitsNBobs.Events
{
    public class OnGroupKeyUp : MonoClick
    {
        [SerializeField] private KeyGroup[] keyGroups;
        public event Action<KeyGroup, KeyCode> KeyGroupUp;

        private void Update()
        {
            foreach (var keyGroup in keyGroups)
            {
                foreach (var keyCode in keyGroup.keyCodes)
                {
                    if (Input.GetKeyUp(keyCode))
                    {
                        KeyGroupUp?.Invoke(keyGroup, keyCode);
                        Click();
                        return;
                    }
                }
            }
        }
    }
}