using UnityEngine;
using Core.ReactiveFields;
using Core.Json;
using System.Collections;

namespace Core.Tappings
{
    public class LevelUpgrade : MonoBehaviour
    {
        [SerializeField] private GameInitializer gameInitializer;
        [SerializeField] private AnimationCurve priiceCurve;
        [SerializeField] private int MaxLevel = 50;
        [SerializeField] private ReactiveField<int> currenLevel = new ReactiveField<int>();
        public int currenLevelProperty
        {
            get=>currenLevel.Value;
            set=>currenLevel.Value=value;
        }
        public ReactiveField<int> CurrenLevel => currenLevel;
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
            float normalizedLevel = (float)currenLevel.Value;
            float price = priiceCurve.Evaluate(normalizedLevel);
            return Mathf.CeilToInt(price);
        }
        public void UpgradeLevel()
        {
            if (currenLevel.Value < MaxLevel)
            {
                int UpgradeCost = GetUpgradeCost();
                currenLevel.Value++;
            } 
        }
        private void Start() 
        {
            currenLevelProperty = 1;
            var loadedCurrenLevel  = new Load<int>("CurrenLevel");
            currenLevel.Value = loadedCurrenLevel;
            levelTextAmount = currenLevel.Value.ToString();
        }
        private void OnEnable()
        {
            if (gameInitializer != null)
            {
                gameInitializer.StopGame -= Save;
                gameInitializer.StopGame += Save;
                gameInitializer.OnSaveComplete += OnSaveComplete;
            }
        }
        private void OnDisable()
        {
            if (gameInitializer != null)
            {
                gameInitializer.StopGame -= Save;
                gameInitializer.OnSaveComplete -= OnSaveComplete;
            }
        }

        private void Save()
        {
            StartCoroutine(SaveCoroutine());
        }

        private IEnumerator SaveCoroutine()

        {
            new Save("CurrenLevel", currenLevel.Value);
            yield return null;
        }
        private void OnSaveComplete()
        {
        }
        
    }
}
