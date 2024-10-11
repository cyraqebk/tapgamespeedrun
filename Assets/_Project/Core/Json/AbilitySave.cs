using UnityEngine;
using System.IO; 

namespace Core.Json
{
    public static class SaveManager
    {
        private static string saveFilePath = Application.persistentDataPath + "/gameSave.json";
        public static void ClearData()
        {
            var emptyData = "{}";

            File.WriteAllText(saveFilePath, emptyData);
        }
        public static void Save<T>(string key, T data)
        {
            new Save(key, data);
        }

        public static T Load<T>(string key, T defaultValue = default)
        {
            Load<T> loadData = new Load<T>(key);
            return loadData ?? defaultValue; // Возвращаем загруженное значение или значение по умолчанию
        }
    }
}
