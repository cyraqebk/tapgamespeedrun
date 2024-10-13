using UnityEngine;
using TMPro;
using Core.Tappings;

namespace UI.Tappings
{
    public class PriceDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text priceText;
        [SerializeField] private TMP_Text lvl;
        [SerializeField] private TMP_Text bonus;
        [SerializeField] private LevelUpgrade levelUpgrade;

        private void OnEnable()
        {
            levelUpgrade.CurrenLevel.Changed += OnPriceChanged;
            priceText.text = "<sprite=0>" + levelUpgrade.GetThePrice().ToString();
            lvl.text = levelUpgrade.CurrenLevel.Value.ToString();
            bonus.text = (levelUpgrade.GetTheSpeed(levelUpgrade.CurrenLevel.Value+1) - levelUpgrade.GetTheSpeed(levelUpgrade.CurrenLevel.Value)).ToString();
        }

        private void OnDisable()
        {
            levelUpgrade.CurrenLevel.Changed -= OnPriceChanged;
        }

        private void OnPriceChanged(int oldValue, int newValue)
        {
            priceText.text = "<sprite=0>" + levelUpgrade.GetThePrice().ToString();
            lvl.text = levelUpgrade.CurrenLevel.Value.ToString();
            bonus.text = (levelUpgrade.GetTheSpeed(levelUpgrade.CurrenLevel.Value+1) - levelUpgrade.GetTheSpeed(levelUpgrade.CurrenLevel.Value)).ToString();
        }
    }
}
