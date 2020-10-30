using System;
using UnityEngine;

namespace BitsNBobs.Events
{
    public class OnEitherKeysPressed : MonoBehaviour
    {
        [SerializeField] private KeyCode[] keyCodes;
        public event Action KeyUp;
        public event Action KeyDown;
        public event Action KeyStay;

        private void Update()
        {
            foreach (var keyCode in keyCodes)
            {
                if (Input.GetKeyDown(keyCode))
                {
                    KeyDown?.Invoke();
                }

                if (Input.GetKeyUp(keyCode))
                {
                    KeyUp?.Invoke();
                }

                if (Input.GetKey(keyCode))
                {
                    KeyStay?.Invoke();
                }
            }
        }
    }
}