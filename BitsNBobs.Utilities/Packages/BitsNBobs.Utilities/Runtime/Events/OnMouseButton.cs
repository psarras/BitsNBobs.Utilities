using System;
using Doozy.Engine.UI;
using UnityEngine;
using UnityEngine.Events;

namespace BitsNBobs.Events
{
    public class OnMouseButton : MonoBehaviour
    {

        [SerializeField] private MouseButton mouseButton;
        public UnityEvent OnMouseUp;
        public UnityEvent OnMouseDown;
        public UnityEvent OnMouse;
        
        private void Update()
        {
            if (Input.GetMouseButtonUp((int) mouseButton))
            {
                OnMouseUp?.Invoke();
            }
            if (Input.GetMouseButtonDown((int) mouseButton))
            {
                OnMouseDown?.Invoke();
            }
            if (Input.GetMouseButton((int) mouseButton))
            {
                OnMouse?.Invoke();
            }
        }

        public enum MouseButton
        {
            Left = 0,
            Middle = 1,
            Right = 2
        }
    }
}