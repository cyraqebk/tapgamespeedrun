using UnityEngine;
using UnityEngine.EventSystems;
using Core.Tappings;
using Core.Wallet;
using System.Collections;

namespace Core.Wallet
{
    public class CollectingCurrency : MonoBehaviour
    {
        [SerializeField] private SoftCurrency softCurrency;
        [SerializeField] private WalletAmount walletAmount;
        [SerializeField] private PassiveIncome passiveIncome;
        private float _checkingMaximumValue;
        public void CollectingCurrencys()
        {
            softCurrency.CurrencyField.Value += (int)Mathf.Floor(walletAmount.WalletField.Value);
            _checkingMaximumValue = walletAmount.WalletField.Value;
            walletAmount.SubtractingValue(walletAmount.WalletField.Value);
            if (_checkingMaximumValue == passiveIncome.MaximumValueWallet)
            {
                StartCoroutine(passiveIncome.AddingToWallet());
            }
        }
    }
}
