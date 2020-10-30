using UnityEngine;
using UnityEngine.Events;

namespace BitsNBobs.Events
{
    public class OnStartUnity : MonoBehaviour
    {
        [SerializeField] private UnityEvent OnStart;

        private void Start()
        {
            OnStart?.Invoke();
        }
    }
}