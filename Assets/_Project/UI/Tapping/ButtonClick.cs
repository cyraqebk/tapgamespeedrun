using UnityEngine;
using UnityEngine.EventSystems;
using Core.Tappings;

namespace UI.Tappings
{
    public class ButtonClickHandler : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private AddMoney addMoney;
        [SerializeField] private int buttonValue;

        public void OnPointerClick(PointerEventData eventData)
        {
            // При клике изменяем значение через приватный сеттер внутри AddMoney
            addMoney.Money += buttonValue;
        }
    }
}

