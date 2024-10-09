using Core.Tappings;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Mining
{
    public class CardUpgrader : MonoBehaviour
    {   
        [SerializeField] private SoftCurrency softCurrency;
        [SerializeField] public int PriceToUpgrade;
        [SerializeField] private Card card;
        [SerializeField] private Button button;
        public delegate void CardUpgrade();  // Делегат для события
        public event CardUpgrade OnCardUpgrade;  // Событие прокачки майнера
        public void Upgrade()   
        {
            if (softCurrency.CurrentAmount >= PriceToUpgrade)
            {
                softCurrency.CurrentAmount -= PriceToUpgrade;
                card.Level++;
                Debug.Log("Карточка улучшена LVL card: " + card.Level);
                PriceToUpgrade += (int)card.cardConfig.PricePerLevel.Evaluate(card.Level);
                OnCardUpgrade?.Invoke();
            }   
            else
            {
                Debug.Log("Недостаточно денег для улучшения");
            }

        }
    }
}
