using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace BitsNBobs.Extensions
{
    public static class LayoutGroupExtension
    {
        public static void EnableDisable(this LayoutGroup group, MonoBehaviour behaviour)
        {
            
            behaviour.StartCoroutine(EnableDisable(group));
        }

        private static IEnumerator EnableDisable(LayoutGroup group)
        {
            group.enabled = false;
            yield return new WaitForSeconds(0.1f);
            group.enabled = true;
        }
        
    }
}