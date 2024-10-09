using UnityEngine;

namespace Core.Mining
{
    public class ProfitPerHour : MonoBehaviour
    {
      [SerializeField] public CardConfig cardConfig;
      [SerializeField] public Card card;
      [SerializeField] public float Hour;
        public void Profit()
        {
            float minute = cardConfig.ProfitPerLevel.Evaluate(card.Level);
            Debug.Log(minute);
        }
        public void ProfitHour()
        {
            Hour = (int)cardConfig.ProfitPerLevel.Evaluate(card.Level) * 60;
            Debug.Log(Hour);
        }
    }
}
