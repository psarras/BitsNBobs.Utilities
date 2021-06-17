using System;
using System.Collections;
using System.Collections.Generic;
//using NaughtyAttributes;
using UnityEngine;

namespace BitsNBobs.Extensions
{
    [RequireComponent(typeof(CanvasGroup))]
    public class CanvasGroupController : MonoBehaviour
    {
        [SerializeField] private bool interaction;
        [SerializeField] private bool blocksRays;
        [SerializeField] private bool visibility;

        public event Action<bool> OnStateChange;
        public bool CurrentState { get; private set; }
        private CanvasGroup canvasGroup;
        
        // Start is called before the first frame update
        void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            CurrentState = canvasGroup.alpha == 1;
        }

        public void TurnOn()
        {
            if (canvasGroup == null)
                canvasGroup = GetComponent<CanvasGroup>();
            canvasGroup.TurnOn(visibility, interaction, blocksRays);
            CurrentState = true;
            OnStateChange?.Invoke(true);
        }
        
        
        public void TurnOff()
        {
            if (canvasGroup == null)
                canvasGroup = GetComponent<CanvasGroup>();
            canvasGroup.TurnOff(visibility, interaction, blocksRays);
            CurrentState = false;
            OnStateChange?.Invoke(false);
        }

        public void State(bool state)
        {
            if(state)
                TurnOn();
            else
                TurnOff();
        }

// #if UNITY_EDITOR
//         [Button()]
// #endif
        public void StateToggle()
        {
            if (canvasGroup == null)
                canvasGroup = GetComponent<CanvasGroup>();
            if(canvasGroup.alpha == 0)
                TurnOn();
            else
                TurnOff();
        }
        
    }
}
