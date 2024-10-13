using UnityEngine;
using UnityEngine.EventSystems;
using Core.Tappings;
using Core.Wallet;
using System.Collections;
using TMPro;
using UI.Animation;

namespace UI.Wallet
{
    public class CollectingCurrencyUI : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private CollectingCurrency collectingCurrency;
        [SerializeField] private AnimationButton animationButton;
        private Vector3 originalScale;
        private void Start() 
        {
            originalScale = transform.localScale;
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            StartCoroutine(animationButton.AnimateButton(transform, originalScale));
            collectingCurrency.CollectingCurrencys();
        }
    }
}
