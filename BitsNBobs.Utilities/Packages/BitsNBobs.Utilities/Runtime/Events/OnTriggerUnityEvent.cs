using NavigationExperiment.Utilities;
using UnityEngine;

namespace BitsNBobs.Events
{
    [RequireComponent(typeof(Collider))]
    public class OnTriggerUnityEvent : MonoBehaviour
    {
        public UnityEventCollider OnEnter;
        public UnityEventCollider OnExit;
        public UnityEventCollider OnStay;

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

namespace NavigationExperiment.Utilities
{
}