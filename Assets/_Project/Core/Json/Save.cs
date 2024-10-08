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
            // Сериализация и запись данных в файл
            string json = JsonConvert.SerializeObject(saves, Formatting.Indented);
            File.WriteAllText(saveFilePath, json);
        }

        public static void LoadFromFile()
        {
            // Проверка наличия файла перед загрузкой
            if (!File.Exists(saveFilePath))
            {
                Debug.LogWarning($"[MEMORY]: Save file not found at {saveFilePath}. A new one will be created on save.");
                saves = new Dictionary<string, string>(); // Инициализация пустого словаря
                return;
            }

            try
            {
                // Чтение и десериализация данных
                string json = File.ReadAllText(saveFilePath);
                saves = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                Debug.Log("[MEMORY]: Save data loaded successfully.");
            }
            catch (Exception e)
            {
                // Обработка ошибок при чтении или десериализации файла
                Debug.LogError($"[MEMORY]: Failed to load save data from {saveFilePath}. Error: {e.Message}");
                saves = new Dictionary<string, string>(); // Обработка ошибки: инициализация пустого словаря
            }
        }
    }

    public class Save
    {
        // Конструктор для сохранения данных
        public Save(string key, object data)
        {
            Memory.saves.Remove(key); // Удаление старых данных по ключу, если они есть
            string jsonData = JsonConvert.SerializeObject(data); // Сериализация данных
            Memory.saves.Add(key, jsonData); // Добавление новых данных
            Memory.SaveToFile(); // Сохранение данных в файл
        }
    }
}
