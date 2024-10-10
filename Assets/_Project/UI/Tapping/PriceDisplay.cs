using UnityEngine;
using TMPro;
using Core.Tappings;

namespace UI.Tappings
{
    public class PriceDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text priceText;
        [SerializeField] private TMP_Text lvl;
        [SerializeField] private LevelUpgrade levelUpgrade;

        private void OnEnable()
        {
            levelUpgrade.levelField.Changed += OnPriceChanged;
            priceText.text = levelUpgrade.levelTextAmount;
        }
        
        private void OnDisable()
        {
            levelUpgrade.levelField.Changed -= OnPriceChanged;
        }

        private void OnPriceChanged(string oldValue, string newValue)
        {
            priceText.text = newValue.ToString();
            lvl.text = levelUpgrade.currenLevelProperty.ToString();
        }
    }
}
