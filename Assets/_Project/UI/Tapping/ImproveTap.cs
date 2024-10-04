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
        [SerializeField] private int currenLevel = 1;
        [SerializeField] private AnimationCurve buffCurve;
        private void Awake()   
        {
            levelUpgrade.levelTextAmount = "Цена за улучшение " + levelUpgrade.GetUpgradeCost(currenLevel) + "   уровень: " + currenLevel;
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            if (softCurrency.CurrentAmount>levelUpgrade.GetUpgradeCost(currenLevel))
            {
                float buff = buffCurve.Evaluate(currenLevel);
                softCurrency.CurrentAmount -=levelUpgrade.GetUpgradeCost(currenLevel);
                levelUpgrade.UpgradeLevel(ref currenLevel);
                buttonClickHandler.currencyIncrementProperty += Mathf.CeilToInt(buff);
                levelUpgrade.levelTextAmount = "Цена за улучшение " + levelUpgrade.GetUpgradeCost(currenLevel) + "   уровень: " + currenLevel;

            }
        }
        
    }
}
