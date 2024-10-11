using UnityEngine;
using Core.ReactiveFields;
using Core.Json;
using System.Collections;

namespace Core.Wallet
{
    public class WalletAmount : MonoBehaviour
    {
        [SerializeField] private GameInitializer _gameInitializer;
        [SerializeField] private ReactiveField<float> _walletCurrency = new ReactiveField<float>(0);
        public ReactiveField<float> WalletField => _walletCurrency;
        public void CurrencyIncrease(float meaning)
        {
            _walletCurrency.Value += meaning;
        }
        public void SubtractingValue(float meaning)
        {
            if ((_walletCurrency.Value - meaning) >= 0)
            {
                _walletCurrency.Value -= meaning;
            }
        }
        private void Start()
        {
            _walletCurrency.Value = SaveManager.Load("_walletCurrency", 0f);
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
            SaveManager.Save("_walletCurrency", _walletCurrency.Value);
        }
        
    }
}
