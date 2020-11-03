using UnityEngine;

namespace BitsNBobs.Singleton
{
    public class SimpleSingleton<T> : MonoBehaviour
        where T : MonoBehaviour
    {
        public static T Instance { get; private set; }

        private void Awake()
        {
            Instance = this as T;
        }
    }
}