using UnityEngine;
using System.IO; 
using System.Collections.Generic;

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

            // Если данных нет, то сразу сохраняем значение по умолчанию
            if (EqualityComparer<T>.Default.Equals(loadData, default(T)))
            {
                Save(key, defaultValue);  // Сохраняем значение по умолчанию
                return defaultValue;
            }

            return loadData;
        }
    }
}
