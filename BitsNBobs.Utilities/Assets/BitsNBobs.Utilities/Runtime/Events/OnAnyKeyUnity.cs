using System;
using UnityEngine;
using UnityEngine.Events;

namespace BitsNBobs.Events
{
    public class OnAnyKeyUnity : MonoBehaviour
    {
        public UnityEvent OnAnyKey;
        public UnityEvent OnAnyKeyDown;

        private void Update()
        {
            if (Input.anyKey)
            {
                OnAnyKey?.Invoke();
            }

            if (Input.anyKeyDown)
            {
                OnAnyKeyDown?.Invoke();
            }
        }
    }
}