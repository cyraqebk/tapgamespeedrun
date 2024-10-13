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
            moneyText.text = "<sprite=0> " + softCurrency.CurrencyField.Value.ToString();
        }

        private void OnDisable()
        {
            softCurrency.CurrencyField.Changed -= CurrencyText;
        }

        private void CurrencyText(long oldValue, long newValue)
        {
            moneyText.text = "<sprite=0> " + newValue.ToString();
        }
    }
}
