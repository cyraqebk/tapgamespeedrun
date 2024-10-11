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
        [SerializeField] private LevelUpgrade levelUpgrade;
        public void OnPointerClick(PointerEventData eventData)
        {
            settings.VibrationPulse();
            softCurrency.CurrencyIncrease(levelUpgrade.GetTheSpeed());
        }
    }
}

