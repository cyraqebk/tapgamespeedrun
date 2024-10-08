using UnityEngine;
using Core.ReactiveFields;
using Core.Tappings;
using System;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.Settings;
using TMPro;

namespace Core.Wallet
{
    public class ImprovingBarWallet : MonoBehaviour
    {
        [SerializeField] private SoftCurrency softCurrency;
        [SerializeField] private AnimationCurve MiningSpeedWeapon;
        [SerializeField] private AnimationCurve CapacityWeapon;
        [SerializeField] private AnimationCurve PriceWeapon;
        [SerializeField] private int levelWeapon;  
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
        public void Awake()
        { 
            ImprovementButtonText();
            CurrentTextLevel();
        }
        public void ImprovementButtonText()
        {
            
        }
        public void CurrentTextLevel()
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
                ImprovementButtonText();
                CurrentTextLevel();
            }
        }
    }
}
