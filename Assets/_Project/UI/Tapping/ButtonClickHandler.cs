using UnityEngine;
using UnityEngine.EventSystems;
using Core.Tappings;

namespace UI.Tappings
{
    public class ButtonClickHandler : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private SoftCurrency softCurrency;
        private int currencyIncrement = 1;
        public int currencyIncrementProperty
        {
            get => currencyIncrement;
            set => currencyIncrement = value;
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            softCurrency.CurrentAmount += currencyIncrement;
        }
    }
}

