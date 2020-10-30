using System;
using UnityEngine;
using UnityEngine.Events;

namespace BitsNBobs.Events
{
    public class OnAwakeUnity : MonoBehaviour
    {
        [SerializeField] private UnityEvent OnAwake;

        private void Awake()
        {
            OnAwake?.Invoke();
        }
    }
}