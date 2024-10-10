using UnityEngine;
using Core.ReactiveFields;
using Core.Json;
using System.Collections;

namespace Core.Tappings
{
    public class SoftCurrency : MonoBehaviour
    {
        [SerializeField] private GameInitializer _gameInitializer;
        [SerializeField] private ReactiveField<int> _currentCurrency = new ReactiveField<int>(0);
        public ReactiveField<int> CurrencyField => _currentCurrency;
        private void Start()
        {
            _gameInitializer.SubscribeToStopGame(OnStopGame);
            LoadPlayerData();
        }
        private void OnDestroy()
        {
            if (_gameInitializer != null)
            {
                _gameInitializer.UnsubscribeFromStopGame(OnStopGame);
            }
        }
        private void OnStopGame()
        {
            SavePlayerData();
        }
        private void SavePlayerData()
        {
            Debug.Log("Save " + _currentCurrency.Value);
            new Save("_currentCurrency", _currentCurrency.Value);
        }
        private void LoadPlayerData()
        {
            Load<int> loadData = new Load<int>("_currentCurrency");
            int loadedCurrency = loadData;
            if (loadedCurrency != 0)
            {
                _currentCurrency.Value = loadedCurrency;
            }
        }
        
        public void CurrencyIncrease(int meaning)
        {
            _currentCurrency.Value += meaning;
        }
        public void SubtractingValue(int meaning)
        {
            if ((_currentCurrency.Value - meaning) >= 0)
            {
                _currentCurrency.Value -= meaning;
            }
        }
    }
}
