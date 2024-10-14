using UnityEngine;
using UnityEngine.EventSystems;
using Core.Tappings;
using Core.Wallet;
using System.Collections;
using Core.Setting;

namespace Core.Wallet
{
    public class CollectingCurrency : MonoBehaviour
    {
        [SerializeField] private SoftCurrency softCurrency;
        [SerializeField] private Settings settings;
        [SerializeField] private WalletAmount walletAmount;
        [SerializeField] private PassiveIncome passiveIncome;
        private float _checkingMaximumValue;
        public void CollectingCurrencys()
        {
            softCurrency.CurrencyField.Value += (int)Mathf.Floor(walletAmount.WalletField.Value);
            _checkingMaximumValue = walletAmount.WalletField.Value;
            walletAmount.SubtractingValue(walletAmount.WalletField.Value);
            settings._collectingCoins.PlayOneShot(settings._collectingCoins.clip);
            if (_checkingMaximumValue == passiveIncome.MaximumValueWallet)
            {
                StartCoroutine(passiveIncome.AddingToWallet());
            }
        }
    }
}
