using UnityEngine;
using Core.ReactiveFields;
using Core.Json;

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
        private void OnApplicationQuit()
        {
            new Save("PlayerData", CurrentAmount);
        }
        private void OnEnable()
        {
            gameInitializer.StopGame += Save;
        }
        private void OnDisable()
        {
            gameInitializer.StopGame -= Save;
        }
        private void Save()
        {
            new Save("CurrentAmount", CurrentAmount);
        }
    }
}

