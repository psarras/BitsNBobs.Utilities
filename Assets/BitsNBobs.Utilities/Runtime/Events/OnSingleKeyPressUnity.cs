using UnityEngine;
using UnityEngine.Events;

namespace BitsNBobs.Events
{
    public class OnSingleKeyPressUnity : MonoBehaviour
    {
        [SerializeField] private KeyCode keyCode;
        public UnityEvent KeyUp;
        public UnityEvent KeyDown;
        public UnityEvent KeyStay;

        private void Update()
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