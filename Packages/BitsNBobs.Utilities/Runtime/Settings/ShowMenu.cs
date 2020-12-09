using System.Collections;
using System.Collections.Generic;
using BitsNBobs.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace BitsNBobs
{
    [RequireComponent(typeof(CanvasGroup))]
    public class ShowMenu : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;

        [SerializeField] private bool IsOn = false;
        
        void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            UpdateState();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                IsOn = !IsOn;

                UpdateState();
            }
            
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
        }

        public void MenuHide()
        {
            canvasGroup.TurnOff();
            IsOn = false;
        }
        
    }
}
