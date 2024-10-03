using UnityEngine;
using UnityEngine.EventSystems;
using Core.Tappings;

namespace UI.Tappings
{
    public class ButtonClickHandler : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private SoftCurrency softCurrency;
        [SerializeField] private int currencyIncrement;

        public void OnPointerClick(PointerEventData eventData)
        {
            softCurrency.CurrentAmount += currencyIncrement;
        }
    }
}

