using System;
using System.Collections;
using UnityEngine;

namespace BitsNBobs.Events
{
    public class Tasker
    {
        private bool update = false;
        public float repeatRate { get; set; } = 0.1f;
        public virtual Action AnyAction { get; set; }
        public Coroutine coroutine { get; private set; }
        public void Update()
        {
            update = true;
        }

        public Coroutine StartWatching(MonoBehaviour handler)
        {
            coroutine = handler.StartCoroutine(UpdateRoutine());
            return coroutine;
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