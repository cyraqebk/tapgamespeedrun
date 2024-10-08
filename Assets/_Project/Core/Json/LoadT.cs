using UnityEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Core.Json
{
    public class Load<T>
    {
        private readonly string _saveName;
        private T _data;

        public T Data
        {
            get
            {
                if (!Memory.saves.ContainsKey(_saveName))
                {
                    Debug.LogWarning($"[MEMORY]: No data found for key '{_saveName}'");
                    return default(T);
                }

                string savedData = Memory.saves[_saveName];
                Type type = typeof(T);

                try
                {
                    // Обработка примитивных типов и строк отдельно
                    if (type.IsPrimitive || type == typeof(decimal))
                    {
                        TypeConverter converter = TypeDescriptor.GetConverter(type);
                        _data = (T)converter.ConvertFromString(savedData);
                    }
                    else if (type == typeof(string))
                    {
                        _data = (T)(object)savedData;
                    }
                    else
                    {
                        // Для сложных объектов - десериализация JSON
                        _data = JsonConvert.DeserializeObject<T>(savedData);
                    }
                }
                catch (Exception e)
                {
                    Debug.LogError($"[MEMORY]: Failed to load data for key '{_saveName}'. Error: {e.Message}");
                    _data = default(T); // Если произошла ошибка, возвращаем default
                }

                return _data;
            }
        }

        // Конструктор, который принимает имя сохранения
        public Load(string saveName)
        {
            _saveName = saveName ?? throw new ArgumentNullException(nameof(saveName), "Save name cannot be null.");
        }

        // Неявное преобразование класса Load<T> в тип T
        public static implicit operator T(Load<T> load)
        {
            return load.Data;
        }
    }
}
