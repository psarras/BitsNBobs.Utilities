using System;
using UnityEngine;

namespace BitsNBobs.Singleton
{
    public class LazyInstantiatedSingleton<T> : MonoBehaviour
        where T : MonoBehaviour
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                    if (instance == null)
                        instance = new GameObject("Instance of " + typeof(T)).AddComponent<T>();
                }

                return instance;
            }
        }
    }
}