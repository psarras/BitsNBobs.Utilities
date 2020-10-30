using System;
using System.Collections;
using BitsNBobs.Utilities.Events;
using UnityEngine;

namespace NavigationExperiment.Utilities
{
    public abstract class MonoSwitch : MonoBehaviour, ISwitch, IState
    {
        public bool State { get; set; }
        public event Action<bool> ChangedState;
        public void FlickOn()
        {
            State = true;
            ChangedState?.Invoke(State);
        }

        public void Reset()
        {
            State = false;
            ChangedState?.Invoke(State);
        }

        public void ResetWithoutNotification()
        {
            State = false;
        }
    }

    public abstract class MonoClick : MonoBehaviour, IClick, IState
    {
        public bool State { get; set; }
        public event Action<bool> ChangedState;

        public void Click()
        {
            State = true;
            ChangedState?.Invoke(State);
            StartCoroutine(FlickBack());
        }

        private IEnumerator FlickBack()
        {
            yield return new WaitForSecondsRealtime(0.1f);
            Reset();
        }

        public void Reset()
        {
            State = false;
            ChangedState?.Invoke(State);
        }

        public void ResetWithoutNotification()
        {
            State = false;
        }
    }
}