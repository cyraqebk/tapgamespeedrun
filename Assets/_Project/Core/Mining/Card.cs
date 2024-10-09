using System.Collections;
using Core.Tappings;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Mining
{
    public class Card : MonoBehaviour
    {
        [SerializeField] public CardConfig cardConfig; // priceperlevel profitperlevel
        [SerializeField] public int Level;
        [SerializeField] public bool IsUnlocked;
        [SerializeField] public SoftCurrency softCurrency;
        [SerializeField] Button buttonToUpgrade;
        public void CheckUnlocked()
        {
            if (Level >= 1 && IsUnlocked)
            {
                Debug.Log("начался майнинг");
                StartCoroutine(CardMining());
                // значит теперь досутпен ап
                buttonToUpgrade.gameObject.SetActive(true);
            }
            else
            {
                Debug.Log("ne mainit");
            }

        }
        IEnumerator CardMining()
        {
            while (true)
            {
            yield return new WaitForSeconds(60);
            softCurrency.CurrentAmount += (int)cardConfig.ProfitPerLevel.Evaluate(Level);
            Debug.Log(softCurrency.CurrentAmount);   
            }
        }
    }
}
