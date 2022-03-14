using UnityEngine;
using System;

namespace BitsNBobs.Data
{
    public abstract class DataManager<T> : MonoBehaviour where T : new ()
    {
        [SerializeField] private string saveFilename;
        public T UserData { get; private set; }
        public Action OnDataUpdate;
        public Action OnDataLoaded;
        
        private void Start()
        {
            LoadOrCreate();
        }

        private void LoadOrCreate()
        {
            UserData = DataIo.LoadOrCreateUnity<T>(saveFilename); //"data.gd"
            OnDataLoaded?.Invoke();
        }

        protected void Save()
        {
            DataIo.SaveDataUnity(saveFilename, UserData);
        }

        public void OnSave()
        {
            Save();
            Debug.Log("OnSave");
            OnDataUpdate?.Invoke();
        }
    }
}