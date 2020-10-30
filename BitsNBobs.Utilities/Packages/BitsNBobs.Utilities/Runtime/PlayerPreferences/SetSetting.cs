using UnityEngine;

namespace BitsNBobs.PlayerPreferences
{
    public class SetSetting : MonoBehaviour
    {
        [SerializeField] public string Key;

        public void SetFloat(float value)
        {
            PlayerPrefs.SetFloat(Key, value);
        }
        
        public void SetString(string value)
        {
            PlayerPrefs.SetString(Key, value);
        }
        
        public void SetInt(int value)
        {
            PlayerPrefs.SetInt(Key, value);
        }
    }
}