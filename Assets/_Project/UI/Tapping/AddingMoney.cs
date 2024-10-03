using UnityEngine;
using TMPro;
using Core.Tappings;

namespace UI.Tappings
{
    public class AddingMoney : MonoBehaviour
    {
        [SerializeField] private TMP_Text moneyText;
        [SerializeField] private SoftCurrency softCurrency;

        private void OnEnable()
        {
            softCurrency.CurrencyField.Changed += OnMoneyChanged;
            moneyText.text = softCurrency.CurrentAmount.ToString();
        }

        private void OnDisable()
        {
            softCurrency.CurrencyField.Changed -= OnMoneyChanged;
        }

        private void OnMoneyChanged(int oldValue, int newValue)
        {
            moneyText.text = newValue.ToString();
        }
    }
}
