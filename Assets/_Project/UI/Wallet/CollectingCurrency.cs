using UnityEngine;
using UnityEngine.EventSystems;
using Core.Tappings;
using Core.Wallet;
using System.Collections;

namespace UI.Wallet
{
    public class CollectingCurrency : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private SoftCurrency softCurrency;
        [SerializeField] private WalletAmount walletAmount;
        [SerializeField] private PassiveIncome passiveIncome;
        public void OnPointerClick(PointerEventData eventData)
        {
            // softCurrency.CurrentAmount += (int)walletAmount.WalletAmountProperty;
            // if (walletAmount.WalletAmountProperty >= passiveIncome.MaximumValueWalletProperty)
            // {
            //     walletAmount.WalletAmountProperty = 0;
            //     StartCoroutine(passiveIncome.RepeatEverySecond());
            // }
            // walletAmount.WalletAmountProperty = 0;
        }
    }
}
