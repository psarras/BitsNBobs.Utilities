using NavigationExperiment.Utilities;
using UnityEngine;
using UnityEngine.Events;

namespace BitsNBobs.Events
{
    [RequireComponent(typeof(Collider))]
    public class OnTriggerSwitchStay : MonoSwitch
    {
        private Collider _collider;
        public UnityEvent<Collider> onStay;
        
        private void Awake()
        {
            _collider = GetComponent<Collider>();
            _collider.isTrigger = true;
        }
        
        public void OnTriggerStay(Collider other)
        {
            FlickOn();
            onStay?.Invoke(other);
        }
        
    }
}