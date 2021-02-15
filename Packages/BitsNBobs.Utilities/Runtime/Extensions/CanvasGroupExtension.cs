using UnityEditor;
using UnityEngine;

namespace BitsNBobs.Extensions
{
    public static class CanvasGroupExtension
    {
        public static void TurnOff(this CanvasGroup canvasGroup, bool visibility = true, bool interaction = true,
            bool blocksRays = true)
        {
            if (visibility)
                canvasGroup.alpha = 0;
            if (interaction)
                canvasGroup.interactable = false;
            if (blocksRays)
                canvasGroup.blocksRaycasts = false;
        }
        
        public static void TurnOn(this CanvasGroup canvasGroup, bool visibility = true, bool interaction = true,
            bool blocksRays = true)
        {
            if (visibility)
                canvasGroup.alpha = 1;
            if (interaction)
                canvasGroup.interactable = true;
            if (blocksRays)
                canvasGroup.blocksRaycasts = true;
        }
        
        public static void SetVisibility(this CanvasGroup canvasGroup, bool state)
        {
            if (state)
                canvasGroup.TurnOn();
            else
                canvasGroup.TurnOff();
        }
        
    }
}