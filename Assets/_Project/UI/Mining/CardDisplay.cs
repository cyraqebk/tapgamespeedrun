using UnityEngine;
using TMPro;
using Core.Mining;

public class CardDisplay : MonoBehaviour
{
    [SerializeField] public ProfitPerHour profitPerHour;
    [SerializeField] private TMP_Text ProfitText;
    [SerializeField] private CardUpgrader cardUpgrader;
    void FixedUpdate() 
    {
           CardProfitText(); 
    }
    void CardProfitText()
    {
        ProfitText.text = "Доход в час: " + profitPerHour.Hour;
        profitPerHour.ProfitHour();
    }
}
