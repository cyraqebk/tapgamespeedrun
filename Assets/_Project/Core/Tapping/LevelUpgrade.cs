using UnityEngine;
using Core.ReactiveFields;
using Core.Json;

namespace Core.Tappings
{
    public class LevelUpgrade : MonoBehaviour
    {
        [SerializeField] private AnimationCurve priiceCurve;
        [SerializeField] private int MaxLevel = 50;
        [SerializeField] private int currenLevel = 1;
        public int currenLevelProperty
        {
            get=>currenLevel;
            set=>currenLevel=value;
        }
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
        public int GetUpgradeCost()
        {
            float normalizedLevel = (float)currenLevel;
            float price = priiceCurve.Evaluate(normalizedLevel);
            return Mathf.CeilToInt(price);
        }
        public void UpgradeLevel()
        {
            if (currenLevel < MaxLevel)
            {
                int UpgradeCost = GetUpgradeCost();
                currenLevel++;
                new Save("currenLevel", currenLevel);
            } 
        }
    }
}
