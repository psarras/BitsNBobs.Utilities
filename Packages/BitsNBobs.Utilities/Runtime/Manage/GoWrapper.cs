using UnityEngine;

namespace BitsNBobs.Manage
{
    public class GoWrapper : IActivatable
    {
        protected GameObject gameObject;
        
        public GoWrapper(GameObject gameObject)
        {
            SetGo(gameObject);
        }

        public void SetGo(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }
        
        public virtual void SetActive(bool state)
        {
            gameObject.SetActive(state);
        }

        public GameObject GetGo()
        {
            return gameObject;
        }
    }
}