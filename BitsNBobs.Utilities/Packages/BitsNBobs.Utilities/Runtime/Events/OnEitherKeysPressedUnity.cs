using UnityEngine;
using UnityEngine.Events;

namespace BitsNBobs.Events
{
    public class OnEitherKeysPressedUnity : MonoBehaviour
    {
        [SerializeField] private KeyCode[] keyCodes;
        public UnityEvent KeyUp;
        public UnityEvent KeyDown;
        public UnityEvent KeyStay;

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