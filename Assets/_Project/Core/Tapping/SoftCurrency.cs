using UnityEngine;
using Core.ReactiveFields;
using Core.Json;
using System.Collections;

namespace Core.Tappings
{
    public class SoftCurrency : MonoBehaviour
    {
        [SerializeField] private GameInitializer _gameInitializer;
        [SerializeField] private ReactiveField<long> _currentCurrency = new ReactiveField<long>(0);
        public ReactiveField<long> CurrencyField => _currentCurrency;
        private void Start()
        {
            _currentCurrency.Value = SaveManager.Load("_currentCurrency", 0);
            _gameInitializer.SubscribeToStopGame(OnStopGame);
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
            SaveManager.Save("_currentCurrency", _currentCurrency.Value);
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
