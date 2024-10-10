using UnityEngine;
using TMPro;
using Core.Tappings;

namespace UI.Tappings
{
    public class MoneyDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text moneyText;
        [SerializeField] private SoftCurrency softCurrency;

        private void OnEnable()
        {
            softCurrency.CurrencyField.Changed += CurrencyText;
            moneyText.text = softCurrency.CurrencyField.Value.ToString();
        }

        private void OnDisable()
        {
            softCurrency.CurrencyField.Changed -= CurrencyText;
        }

        private void CurrencyText(int oldValue, int newValue)
        {
            moneyText.text = newValue.ToString();
        }
    }
}
