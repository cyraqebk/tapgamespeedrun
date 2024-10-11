using Core.Json;
using Core.Tappings;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Mining
{
    public class CardUnlocker : MonoBehaviour
    {
        [SerializeField] private SoftCurrency softCurrency;
        [SerializeField] private Card card;
        [SerializeField] private Button button;
        [SerializeField] private ProfitPerHour profitPerHour;
        [SerializeField] private SaveCard saveCard;
        public int PriceToUnlock;
        public delegate void CardUnlock(); 
        public event CardUnlock OnCardUnlock;
        
        private void Start()
        {
            saveCard.LoadProgress();
            OnCardUnlock += saveCard.SaveProgress;
        }
        public void Unlock() 
        {
            if (softCurrency.CurrentAmount >= PriceToUnlock)
            {
                softCurrency.CurrentAmount -= PriceToUnlock;
                card.Level++;
                card.IsUnlocked = true;
                button.gameObject.SetActive(false);
                card.CheckUnlocked();
                OnCardUnlock?.Invoke();
            }
            else
            {
                Debug.LogError("");
            }
        }
        private void OnDestroy()
        {
            OnCardUnlock -= saveCard.SaveProgress;
        }
    }
}
