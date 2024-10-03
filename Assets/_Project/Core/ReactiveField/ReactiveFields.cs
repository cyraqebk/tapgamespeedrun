    using UnityEngine;
    using System;

    namespace Core.ReactiveFields
    {
        [Serializable]
        public class ReactiveField<T>
        {
            [SerializeField] private T _value = default;
            public delegate void ChangedListener(T oldValue, T newValue);
            public event ChangedListener Changed;

            public ReactiveField(T value)
            {
                _value = value;
            }

            public ReactiveField()
            {
            }

            public T Value
            {
                get
                {
                    return _value;
                }
                set
                {
                    T oldValue = _value;
                    _value = value;
                    Debug.Log("Ищем подписчиков");

                    Changed?.Invoke(oldValue, _value);
                }
            }
        }
    }
