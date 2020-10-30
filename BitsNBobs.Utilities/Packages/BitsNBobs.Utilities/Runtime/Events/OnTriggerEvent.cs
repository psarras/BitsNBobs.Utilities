using System;
using UnityEngine;

namespace BitsNBobs.Events
{
    [RequireComponent(typeof(Collider))]
    public class OnTriggerEvent : MonoBehaviour
    {
        public event Action<Collider> OnEnter;
        public event Action<Collider> OnExit;
        public event Action<Collider> OnStay;

        private Collider _collider;
        
        private void Awake()
        {
            _collider = GetComponent<Collider>();
            _collider.isTrigger = true;
        }

        public void OnTriggerEnter(Collider other)
        {
            OnEnter?.Invoke(other);
        }

        public void OnTriggerExit(Collider other)
        {
            OnExit?.Invoke(other);
        }

        public void OnTriggerStay(Collider other)
        {
            OnStay?.Invoke(other);
        }
    }
}
