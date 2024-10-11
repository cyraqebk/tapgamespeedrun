using UnityEngine;

namespace Core.Mining
{
    public class SaveCard : MonoBehaviour
    {
        [SerializeField] Card card;
        [SerializeField] ProfitPerHour profitPerHour;
        public void SaveProgress()
        {
            PlayerPrefs.SetInt("CardLevel", card.Level);
            PlayerPrefs.SetInt("CardIsUnlocked", card.IsUnlocked ? 1 : 0);
            PlayerPrefs.Save();
        }

        public void LoadProgress()
        {
            card.Level = PlayerPrefs.GetInt("CardLevel", 1);
            card.IsUnlocked = PlayerPrefs.GetInt("CardIsUnlocked", 0) == 1;
        }
    }
}
