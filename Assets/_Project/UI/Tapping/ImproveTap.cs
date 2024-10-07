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
        [SerializeField] private AnimationCurve buffCurve;
        private void Awake()   
        {
            levelUpgrade.levelTextAmount = "Цена за улучшение " + levelUpgrade.GetUpgradeCost() + "   уровень: " + levelUpgrade.currenLevelProperty;
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            if (softCurrency.CurrentAmount>levelUpgrade.GetUpgradeCost())
            {
                float buff = buffCurve.Evaluate(levelUpgrade.currenLevelProperty);
                softCurrency.CurrentAmount -=levelUpgrade.GetUpgradeCost();
                levelUpgrade.UpgradeLevel();
                buttonClickHandler.currencyIncrementProperty = Mathf.CeilToInt(buff);
                levelUpgrade.levelTextAmount = "Цена за улучшение " + levelUpgrade.GetUpgradeCost() + "   уровень: " + levelUpgrade.currenLevelProperty;
            }
        }
        
    }
}
