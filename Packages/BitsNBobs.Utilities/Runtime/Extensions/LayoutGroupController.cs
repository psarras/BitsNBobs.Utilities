using UnityEngine;

namespace BitsNBobs.Extensions
{
    public class LayoutGroupController : MonoBehaviour
    {
        public void RefreshLayour()
        {
            LayoutGroupExtension.RefreshLayoutGroupsImmediateAndRecursive(gameObject);
        }
    }
}