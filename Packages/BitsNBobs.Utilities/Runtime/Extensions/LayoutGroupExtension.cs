using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace BitsNBobs.Extensions
{
    public static class LayoutGroupExtension
    {
        public static void EnableDisable(this LayoutGroup group, MonoBehaviour behaviour, float wait = 0.1f)
        {
            behaviour.StartCoroutine(EnableDisable(group, wait));
        }

        private static IEnumerator EnableDisable(LayoutGroup group, float wait = 0.1f)
        {
            group.enabled = false;
            yield return new WaitForSeconds(wait);
            group.enabled = true;
        }

        public static void RefreshLayoutGroupsImmediateAndRecursive(GameObject root)
        {
            var componentsInChildren = root.GetComponentsInChildren<LayoutGroup>(true);
            foreach (var layoutGroup in componentsInChildren)
            {
                LayoutRebuilder.ForceRebuildLayoutImmediate(layoutGroup.GetComponent<RectTransform>());
            }

            var parent = root.GetComponent<LayoutGroup>();
            if (parent != null)
            {
                var rectTransform = parent.GetComponent<RectTransform>();
                if (rectTransform != null)
                    LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
            }
        }
    }
}