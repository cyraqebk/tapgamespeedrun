using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Core.Json
{
    public static class Memory
    {
        public static Dictionary<string, string> saves = new Dictionary<string, string>();
        private static string saveFilePath = Application.persistentDataPath + "/gameSave.json";

        public static void SaveToFile()
        {
            try
            {
                string json = JsonConvert.SerializeObject(saves, Formatting.Indented);
                File.WriteAllText(saveFilePath, json);
                Debug.Log($"[MEMORY]: Save file created at {saveFilePath}"); // Лог для проверки сохранения
            }
            catch (Exception e)
            {
                Debug.LogError($"[MEMORY]: Failed to save file: {e.Message}"); // Обработка ошибок
            }
        }

        public static void LoadFromFile()
        {
            if (!File.Exists(saveFilePath))
            {
                Debug.LogWarning($"[MEMORY]: Save file not found at {saveFilePath}. A new one will be created on save.");
                saves = new Dictionary<string, string>();
                return;
            }

            try
            {
                string json = File.ReadAllText(saveFilePath);
                saves = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                Debug.Log("[MEMORY]: Save data loaded successfully.");
            }
            catch (Exception e)
            {
                Debug.LogError($"[MEMORY]: Failed to load save data from {saveFilePath}. Error: {e.Message}");
                saves = new Dictionary<string, string>();
            }
        }

        public static void ClearSaves()
        {
            saves.Clear();
            Debug.Log("[MEMORY]: Save data cleared.");
        }

        // Метод для создания тестового файла
        public static void CreateTestFile()
        {
            string testFilePath = Application.persistentDataPath + "/testFile.txt";
            try
            {
                File.WriteAllText(testFilePath, "This is a test file.");
                Debug.Log($"[MEMORY]: Test file created at {testFilePath}"); // Лог для проверки создания тестового файла
            }
            catch (Exception e)
            {
                Debug.LogError($"[MEMORY]: Failed to create test file: {e.Message}"); // Обработка ошибок
            }
        }
    }

    public class Save
    {
        public Save(string key, object data)
        {
            Memory.saves.Remove(key);
            
            // Для примитивных типов и строки сохраняем без сериализации
            if (data is int || data is float || data is string || data is double || data is bool)
            {
                Memory.saves.Add(key, data.ToString());
            }
            else
            {
                // Для остальных типов данных сериализуем
                string jsonData = JsonConvert.SerializeObject(data);
                Memory.saves.Add(key, jsonData);
            }

            Memory.SaveToFile();
        }
    }
}
