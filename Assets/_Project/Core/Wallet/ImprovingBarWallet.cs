using UnityEngine;
using Core.ReactiveFields;
using Core.Tappings;
using System;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.Settings;
using TMPro;
using Core.Json;
using System.Collections;
using Core.Setting;

namespace Core.Wallet
{
    public class ImprovingBarWallet : MonoBehaviour
    {
        [SerializeField] private GameInitializer gameInitializer;
        [SerializeField] private SoftCurrency softCurrency;
        [SerializeField] private Settings settings;
        [SerializeField] private AnimationCurve _miningSpeedWeapon;
        [SerializeField] private AnimationCurve _CapacityWeapon;
        [SerializeField] private AnimationCurve _priceWeapon;
        [SerializeField] private ReactiveField<int> _lvl = new ReactiveField<int>(1);
        public ReactiveField<int> Lvl => _lvl;
        [SerializeField] public PassiveIncome passiveIncome;
        [SerializeField] private int _maxLevelWeapon = 100;
        private DateTime startTime;
        private DateTime endTime;

        private void Start()
        {
            _lvl.Value = SaveManager.Load("_lvl", 1);
            passiveIncome.GetSpeed(SaveManager.Load("_speedWallet", 1f));
            passiveIncome.GetMaximumVolume(SaveManager.Load("_waximumValueWallet", 1000));
            gameInitializer.SubscribeToStopGame(OnStopGame);
            startTime = SaveManager.Load("_timeWallet", DateTime.Now);
            endTime = DateTime.Now;
            TimeSpan timeDifference = endTime - startTime;
            double seconds = timeDifference.TotalSeconds;
            if (passiveIncome.PassivImpruv((float)seconds * passiveIncome.MiningSpeed))
            {
                passiveIncome._walletAmount.CurrencyIncrease((float)seconds * passiveIncome.MiningSpeed);
            }
            else
            {
                passiveIncome._walletAmount.CurrencyIncrease(passiveIncome.MaximumValueWallet - passiveIncome._walletAmount.WalletField.Value);
            }

        }
        private void OnApplicationPause(bool pauseStatus)
        {
            if (!pauseStatus)
            {
                startTime = SaveManager.Load("_timeWallet", DateTime.Now);
                endTime = DateTime.Now;
                TimeSpan timeDifference = endTime - startTime;
                double seconds = timeDifference.TotalSeconds;
                if (passiveIncome.PassivImpruv((float)seconds * passiveIncome.MiningSpeed))
                {
                    passiveIncome._walletAmount.CurrencyIncrease((float)seconds * passiveIncome.MiningSpeed);
                }
                else
                {
                    passiveIncome._walletAmount.CurrencyIncrease(passiveIncome.MaximumValueWallet - passiveIncome._walletAmount.WalletField.Value);
                }
            }
        }
        private void OnDestroy()
        {
            if (gameInitializer != null)
            {
                gameInitializer.UnsubscribeFromStopGame(OnStopGame);
            }
        }

        private void OnStopGame()
        {
            startTime = DateTime.Now;
            SaveManager.Save("_timeWallet", startTime);
            SaveManager.Save("_lvl", _lvl.Value);
            SaveManager.Save("_speedWallet", passiveIncome.MiningSpeed);
            SaveManager.Save("_waximumValueWallet", passiveIncome.MaximumValueWallet);
        }
        

        public int GettingPriceWeapon(int level)
        {
            float price = _priceWeapon.Evaluate(level);
            return Mathf.CeilToInt(price);
        }
        public float GettingMiningSpeedWeapon(int level)
        {
            float speed = _miningSpeedWeapon.Evaluate(level);
            return speed;
        }
        public int GettingCapacityWeapon(int level)
        {
            float capacity = _CapacityWeapon.Evaluate(level);
            return Mathf.CeilToInt(capacity);
        }
        public void UpgradeLevel()
        {
            if (_lvl.Value < _maxLevelWeapon &&  GettingPriceWeapon(_lvl.Value+1) <= softCurrency.CurrencyField.Value)
            {
                Debug.Log("Vibrrr");
                settings.VibrationPulse();
                _lvl.Value++;  
                softCurrency.SubtractingValue(GettingPriceWeapon(_lvl.Value));
                passiveIncome.GetMaximumVolume(GettingCapacityWeapon(_lvl.Value));
                passiveIncome.GetSpeed(GettingMiningSpeedWeapon(_lvl.Value));
            }
        }
    }
}
