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
        private void Start()   
        {
            levelUpgrade.levelTextAmount = levelUpgrade.GetUpgradeCost().ToString();
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            if (softCurrency.CurrentAmount>levelUpgrade.GetUpgradeCost())
            {
                softCurrency.CurrentAmount -=levelUpgrade.GetUpgradeCost();
                levelUpgrade.UpgradeLevel();
                levelUpgrade.levelTextAmount = levelUpgrade.GetUpgradeCost().ToString();
            }
        }
        private void OnEnable()
        {
            levelUpgrade.CurrenLevel.Changed += OnPriceChanged;
            Debug.Log(levelUpgrade.currenLevelProperty);
            float buff = buffCurve.Evaluate(levelUpgrade.currenLevelProperty);
            buttonClickHandler.currencyIncrementProperty = Mathf.CeilToInt(buff);
        }
        
        private void OnDisable()
        {
            levelUpgrade.CurrenLevel.Changed -= OnPriceChanged;
        }

        private void OnPriceChanged(int oldValue, int newValue)
        {
            Debug.Log(levelUpgrade.currenLevelProperty);
            float buff = buffCurve.Evaluate(levelUpgrade.currenLevelProperty);
            buttonClickHandler.currencyIncrementProperty = Mathf.CeilToInt(buff);
        }
        
    }
}
