using UnityEngine;

namespace BitsNBobs.Extensions
{
    public class GameObjectController : MonoBehaviour
    {
        public void ToggleVisibility()
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}