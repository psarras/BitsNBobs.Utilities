using System;
using System.Collections;
using UnityEngine;

namespace BitsNBobs.Events
{
    public class Tasker
    {
        private bool update = false;
        public float repeatRate { get; set; } = 0.1f;
        public Action AnyAction { get; set; }

        public void Update()
        {
            update = true;
        }

        public Coroutine StartWatching(MonoBehaviour handler)
        {
            return handler.StartCoroutine(UpdateRoutine());
        }

        public IEnumerator UpdateRoutine()
        {
            Debug.LogWarning("Tasker Start");
            while (true)
            {
                if (!update)
                {
                    yield return new WaitForSeconds(repeatRate);
                    continue;
                }

                AnyAction();
                update = false;
                yield return new WaitForSeconds(repeatRate);
            }
            Debug.LogError("Tasker Stopped");
        }
    }
}