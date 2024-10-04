using UnityEngine;
using Core.ReactiveFields;

namespace Core.Tappings
{
    public class LevelUpgrade : MonoBehaviour
    {
        [SerializeField] private AnimationCurve priiceCurve;
        [SerializeField] private int MaxLevel = 50;
        [SerializeField] private ReactiveField<string> levelText = new ReactiveField<string>("");
        public string levelTextAmount
        {
            get => levelText.Value;
            set => levelText.Value = value;
        }
        public ReactiveField<string> levelField => levelText;
        public int MaxLevelProperty
        {
            get => MaxLevel;
        }
        public int GetUpgradeCost(int Level)
        {
            float normalizedLevel = (float)Level;
            float price = priiceCurve.Evaluate(normalizedLevel);
            Debug.Log(Mathf.CeilToInt(price));
            return Mathf.CeilToInt(price);
        }
        public void UpgradeLevel(ref int currenLevel)
        {
            if (currenLevel < MaxLevel)
            {
                int UpgradeCost = GetUpgradeCost(currenLevel);
                Debug.Log("Стоимость апгрейда уровня " + currenLevel + ": " + UpgradeCost + " Монет");
                currenLevel++;
            }
            else
            {
                Debug.Log("Максимальный уровень достигнут!!!");
            }
        }
    }
}
