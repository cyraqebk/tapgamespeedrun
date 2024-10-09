using UnityEngine;
using TMPro;
using Core.Mining;

public class CardUpgradePrice : MonoBehaviour
{
    [SerializeField] private TMP_Text UpgradeText;
    [SerializeField] private CardUpgrader cardUpgrader;
    private void OnEnable() 
    {
        cardUpgrader.OnCardUpgrade += CardPriceText;
        CardPriceText();
    }
    void CardPriceText()
    {
        UpgradeText.text = $"Улучшить: {cardUpgrader.PriceToUpgrade}";
    }
}
