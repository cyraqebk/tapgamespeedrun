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

namespace Core.Wallet
{
    public class ImprovingBarWallet : MonoBehaviour
    {
        [SerializeField] private GameInitializer gameInitializer;
        [SerializeField] private SoftCurrency softCurrency;
        [SerializeField] private AnimationCurve MiningSpeedWeapon;
        [SerializeField] private AnimationCurve CapacityWeapon;
        [SerializeField] private AnimationCurve PriceWeapon;
        public delegate void ChangedWallet();
        public event ChangedWallet Changed;
        [SerializeField] private int levelWeapon = 1;  
        public int levelWeaponProperty
        {
            get=>levelWeapon;
            set=>levelWeapon = value;
        }
        [SerializeField] private PassiveIncome passiveIncome;
        [SerializeField] private int MaxLevelWeapon = 100;
        [SerializeField] private TMP_Text _lvlText;
        [SerializeField] private TMP_Text _speedText;
        [SerializeField] private ReactiveField<string> WeaponLevelText = new ReactiveField<string>("");
        public string WeaponLevelTextProperty
        {
            get=>WeaponLevelText.Value;
            set=>WeaponLevelText.Value = value;
        }
        public ReactiveField<string> WeaponLevelTextField => WeaponLevelText;
        private void Start() 
        {
            if (Memory.saves.ContainsKey("LevelWeapon"))
            {
                var loadedlevelWeapon  = new Load<int>("LevelWeapon");
                if (loadedlevelWeapon!=0)
                {
                    levelWeapon = loadedlevelWeapon;
                }
            }
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
            new Save("LevelWeapon", levelWeapon);
            yield return null;
        }

        private void OnSaveComplete()
        {
        }

        public int GettingPriceWeapon(int level)
        {
            float price = PriceWeapon.Evaluate(level+1);
            return Mathf.CeilToInt(price);
        }
        public float GettingMiningSpeedWeapon(int level)
        {
            float speed = MiningSpeedWeapon.Evaluate(level+1);
            return speed;
        }
        public int GettingCapacityWeapon(int level)
        {
            float capacity = CapacityWeapon.Evaluate(level+1);
            return Mathf.CeilToInt(capacity);
        }
        public void UpgradeLevel()
        {
            if (levelWeapon < MaxLevelWeapon &&  GettingPriceWeapon(levelWeapon) <= softCurrency.CurrentAmount)
            {
                softCurrency.CurrentAmount -= GettingPriceWeapon(levelWeapon);
                passiveIncome.MaximumValueWalletProperty = GettingCapacityWeapon(levelWeapon);
                passiveIncome.MiningSpeedProperty = GettingMiningSpeedWeapon(levelWeapon);
                levelWeapon++;  
                Changed?.Invoke();
            }
        }
    }
}
