using UnityEngine;
using UnityEngine.EventSystems;
using Core.Tappings;
using Core.Wallet;
using System.Collections;
using TMPro;

namespace UI.Wallet
{
    public class CollectingCurrencyUI : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private CollectingCurrency collectingCurrency;
        public void OnPointerClick(PointerEventData eventData)
        {
            collectingCurrency.CollectingCurrencys();
        }
    }
}
