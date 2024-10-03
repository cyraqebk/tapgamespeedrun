using UnityEngine;
using Core.ReactiveFields;

namespace Core.Tappings
{
    public class AddMoney : MonoBehaviour
    {
        // Инициализация ReactiveField<int> с начальным значением 0
        [SerializeField] private ReactiveField<int> money = new ReactiveField<int>(0);

        // Геттер и сеттер для изменения количества валюты
        public int Money
        {
            get => money.Value;
            set => money.Value = value;
        }

        // Геттер для доступа к полю money, чтобы подписываться на его события
        public ReactiveField<int> MoneyField => money;
    }
}

