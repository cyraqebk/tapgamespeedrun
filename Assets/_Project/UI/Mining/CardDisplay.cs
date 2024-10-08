using UnityEngine;
using TMPro;
using Core.Mining;

public class CardDisplay : MonoBehaviour
{
    [SerializeField] public ProfitPerHour profitPerHour;
    [SerializeField] private TMP_Text ProfitText;
    [SerializeField] private TMP_Text LevelText;
    [SerializeField] private CardUpgrader cardUpgrader;
    [SerializeField] private CardUnlocker cardUnlocker;
    [SerializeField] private Card card;
    private void OnEnable() 
    {
        cardUpgrader.OnCardUpgrade += CardProfitText; 
        cardUnlocker.OnCardUnlock += CardProfitText;
        profitPerHour.ProfitHour(); 
    }

    private void OnDisable() 
    {
        cardUpgrader.OnCardUpgrade -= CardProfitText;
        cardUnlocker.OnCardUnlock -= CardProfitText;
    }
    void CardProfitText()
    {
        profitPerHour.ProfitHour();
        ProfitText.text = $"{profitPerHour.Hour}";
        LevelText.text = $"{card.Level}";
    }
}
