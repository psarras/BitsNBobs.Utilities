using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace BitsNBobs.Data
{
    public static class DataIo
    {
        public static T LoadOrCreate<T>(string directory, string file) where T : new()
        {
            var path = Path.Combine(directory, file);
            if (File.Exists(path))
                return LoadData<T>(directory, file);
            var t = new T();
            SaveData(directory, file, t);
            return t;
        }

        public static T LoadOrCreateUnity<T>(string file) where T : new()
        {
            return LoadOrCreate<T>(Application.persistentDataPath, file);
        }

        public static void SaveDataUnity<T>(string file, T data)
        {
            SaveData<T>(Application.persistentDataPath, file, data);
        }

        public static T LoadData<T>(string directory, string file) where T : new()
        {
            var path = Path.Combine(directory, file);
            var data = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(data);
        }

        public static void SaveData<T>(string directory, string file, T data)
        {
            var txt = JsonConvert.SerializeObject(data, Formatting.Indented);
            var path = Path.Combine(directory, file);
            File.WriteAllText(path, txt);
        }
    }
}