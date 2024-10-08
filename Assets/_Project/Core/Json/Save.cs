using UnityEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            string json = JsonConvert.SerializeObject(saves, Formatting.Indented);
            File.WriteAllText(saveFilePath, json);
            Debug.Log(Application.persistentDataPath);
        }

        public static void LoadFromFile()
        {
            if (File.Exists(saveFilePath))
            {
                string json = File.ReadAllText(saveFilePath);
                saves = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                Debug.Log($"[MEMORY]: Data loaded from file at {saveFilePath}");
            }
            else
            {
                Debug.LogWarning($"[MEMORY]: No save file found at {saveFilePath}");
            }
        }
    }
    public class Save
    {
        public Save(string key, object data)
        {
            Memory.saves.Remove(key);
            string jsonData = JsonConvert.SerializeObject(data);
            Memory.saves.Add(key, jsonData);
            Debug.Log($"[MEMORY]: Save with key {key} and data {jsonData} was created");
            Memory.SaveToFile();
        }
    }
}
