using UnityEngine;
using UnityEngine.EventSystems;
using Core.Tappings;

namespace UI.Tappings
{
        public class ButtonClickHandler : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Tapping tapping;
        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log(" Кликнул");
            tapping.Tap();
        }
    }
}
