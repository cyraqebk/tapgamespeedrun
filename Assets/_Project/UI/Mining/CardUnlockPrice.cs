using UnityEngine;
using UnityEngine.UI; 
using TMPro;
using Core.Mining;

public class CardUnlockPrice : MonoBehaviour
{
    [SerializeField] private TMP_Text UnlockText;
    [SerializeField] private CardUnlocker cardUnlocker;
    private void Start() 
    {
        if (cardUnlocker != null)
        {
            CardPriceText();
        }
        else
        {
            Debug.LogError("ItemPrice не назначен!");
        }

    }
    void CardPriceText()
    {
        UnlockText.text = $"{cardUnlocker.PriceToUnlock}";
    }
}
