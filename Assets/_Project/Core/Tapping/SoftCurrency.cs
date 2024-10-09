using UnityEngine;
using Core.ReactiveFields;
using Core.Json;
using System.Collections;

namespace Core.Tappings
{
    public class SoftCurrency : MonoBehaviour
    {
        [SerializeField] private GameInitializer gameInitializer;
        [SerializeField] private ReactiveField<int> currentCurrency = new ReactiveField<int>(0);
        public int CurrentAmount
        {
            get => currentCurrency.Value;
            set => currentCurrency.Value = value;
        }
        public ReactiveField<int> CurrencyField => currentCurrency;
        private void Start() 
        {
            var loadedCurrency  = new Load<int>("CurrentAmount");
            CurrentAmount = loadedCurrency;
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
            new Save("CurrentAmount", CurrentAmount);
            yield return null;
        }
        private void OnSaveComplete()
        {
        }
    }
}

