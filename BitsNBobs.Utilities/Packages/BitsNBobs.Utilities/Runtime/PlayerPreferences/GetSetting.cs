using UnityEngine;

namespace BitsNBobs.PlayerPreferences
{
    public class GetSetting : MonoBehaviour
    {
        [SerializeField] public string Key;

        public float GetFloat(float value)
        {
            return PlayerPrefs.GetFloat(Key);
        }
        
        public string GetString(string value)
        {
            return PlayerPrefs.GetString(Key);
        }
        
        public int GetInt(int value)
        {
            return PlayerPrefs.GetInt(Key);
        }
    }
}