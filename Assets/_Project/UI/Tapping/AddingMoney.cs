using UnityEngine;
using TMPro;
using Core.Tappings;

namespace UI.Tappings
{
    public class AddingMoney : MonoBehaviour
    {
        [SerializeField] private TMP_Text moneyText;
        [SerializeField] private AddMoney addMoney;

        private void OnEnable()
        {
            // Подписываемся на событие изменения валюты через MoneyField
            addMoney.MoneyField.Changed += OnMoneyChanged;
            // Обновляем текст на экране
            moneyText.text = addMoney.Money.ToString();
        }

        private void OnDisable()
        {
            // Отписываемся от события изменения валюты
            addMoney.MoneyField.Changed -= OnMoneyChanged;
        }

        private void OnMoneyChanged(int oldValue, int newValue)
        {
            // Обновляем текст при изменении валюты
            moneyText.text = newValue.ToString();
        }
    }
}
