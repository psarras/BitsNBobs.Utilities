using System;
using BitsNBobs.Extensions;
using UnityEngine;

namespace BitsNBobs
{
    [RequireComponent(typeof(CanvasGroup))]
    public class PopUp : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] protected bool IsOn = false;
        public event Action Opening;
        public event Action Hiding; 
        void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            UpdateState();
        }
        
        public void UpdateState()
        {
            if (IsOn)
            {
                MenuShow();
            }
            else
            {
                MenuHide();
            }
        }

        public void MenuShow()
        {
            canvasGroup.TurnOn();
            IsOn = true;
            Opening?.Invoke();
        }

        public void MenuHide()
        {
            canvasGroup.TurnOff();
            IsOn = false;
            Hiding?.Invoke();
        }

    }
}