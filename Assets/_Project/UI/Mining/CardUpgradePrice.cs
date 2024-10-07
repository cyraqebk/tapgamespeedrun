using UnityEngine;
using UnityEngine.UI; 
using TMPro;
using Core.Mining;

public class CardUpgradePrice : MonoBehaviour
{
    [SerializeField] private TMP_Text UpgradeText;
    [SerializeField] private CardUpgrader cardUpgrader;
    private void Start() 
    {
        if (cardUpgrader != null)
        {
            CardPriceText();
        }
        else
        {
            Debug.LogError("обьект не назначен!");
        }

    }
    void CardPriceText()
    {
        UpgradeText.text = "Улучшить: " + cardUpgrader.PriceToUpgrade;
    }
}
