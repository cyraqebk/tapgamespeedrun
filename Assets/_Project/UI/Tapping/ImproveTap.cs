using UnityEngine;
using UnityEngine.EventSystems;
using Core.Tappings;

namespace UI.Tappings
{
    public class ImproveTap : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private LevelUpgrade levelUpgrade;
        [SerializeField] private ButtonClickHandler buttonClickHandler;
        [SerializeField] private SoftCurrency softCurrency;
        public void OnPointerClick(PointerEventData eventData)
        {
            levelUpgrade.Improvement();
        }
        
    }
}
