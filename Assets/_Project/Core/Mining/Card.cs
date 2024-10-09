using System.Collections;
using Core.Tappings;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Mining
{
    public class Card : MonoBehaviour
    {
        public CardConfig cardConfig;
        public string cardName;
        public int Level;
        public bool IsUnlocked;
        public SoftCurrency softCurrency;
        public Button buttonToUpgrade;
        private void Start() {
            string prefabName = transform.name;
            Debug.Log("Prefab Name: " + prefabName);
        }
        public void CheckUnlocked()
        {
            if (Level >= 1 && IsUnlocked)
            {
                StartCoroutine(CardMining());
                buttonToUpgrade.gameObject.SetActive(true);
            }
            else
            {
                Debug.LogError("");
            }

        }
        IEnumerator CardMining()
        {
            while (true)
            {
            yield return new WaitForSeconds(60);
            softCurrency.CurrentAmount += (int)cardConfig.ProfitPerLevel.Evaluate(Level);  
            }
        }
    }
}
