using UnityEngine;
using UnityEngine.EventSystems;
using Core.Tappings;
using Core.Setting;

namespace UI.Tappings
{
    public class ButtonClickHandler : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private SoftCurrency softCurrency;
        [SerializeField] private Settings settings;
        private int currencyIncrement = 1;
        public int currencyIncrementProperty
        {
            get => currencyIncrement;
            set => currencyIncrement = value;
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            settings.vibrationpusk();
            softCurrency.CurrentAmount += currencyIncrement;
        }
    }
}

