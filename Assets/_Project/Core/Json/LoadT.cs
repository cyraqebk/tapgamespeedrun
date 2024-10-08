using UnityEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Newtonsoft.Json;

namespace Core.Json
{
    public class Load<T>
    {
        private string _saveName;
        private T _data;

        public T Data
        {
            get
            {
                if (!Memory.saves.ContainsKey(_saveName))
                {
                    _data = default(T);
                    Debug.Log($"[MEMORY]: No data found for key {_saveName}");
                    return _data;
                }

                string savedData = Memory.saves[_saveName];
                Type type = typeof(T);

                if (type.IsPrimitive || type == typeof(decimal))
                {
                    TypeConverter converter = TypeDescriptor.GetConverter(type);
                    _data = (T)converter.ConvertFrom(savedData);
                }
                else if (type == typeof(string))
                {
                    _data = (T)(object)savedData;
                }
                else
                {
                    _data = JsonConvert.DeserializeObject<T>(savedData);
                }

                Debug.Log($"[MEMORY]: Loaded by key {_saveName}: {JsonConvert.SerializeObject(_data)}");
                return _data;
            }
        }

        public Load(string saveName)
        {
            _saveName = saveName;
        }

        public static implicit operator T(Load<T> load)
        {
            return load.Data;
        }
    }
}
