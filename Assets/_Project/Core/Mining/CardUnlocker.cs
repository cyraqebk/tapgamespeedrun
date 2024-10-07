using Core.Tappings;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Mining
{
    public class CardUnlocker : MonoBehaviour
    {
        [SerializeField] private SoftCurrency softCurrency;
        [SerializeField] public int PriceToUnlock;
        [SerializeField] private Card card;
        [SerializeField] private Button button;
        public void Unlock() 
        {
            if (softCurrency.CurrentAmount >= PriceToUnlock)
            {
                softCurrency.CurrentAmount -= PriceToUnlock;
                card.Level++;
                card.IsUnlocked = true;
                Debug.Log("Карточка куплена LVL card: " + card.Level);
                button.gameObject.SetActive(false);
                card.CheckUnlocked();
            }
            else
            {
                Debug.Log("Недостаточно денег для покупки");
            }
        }
    }
}
