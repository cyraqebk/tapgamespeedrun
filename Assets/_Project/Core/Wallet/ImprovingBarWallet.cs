using UnityEngine;
using Core.ReactiveFields;
using Core.Tappings;
using System;

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
        private string Text1;
        private string Text2;
        [SerializeField] private ReactiveField<string> WeaponLevelText = new ReactiveField<string>("");
        public string WeaponLevelTextProperty
        {
            get=>WeaponLevelText.Value;
            set=>WeaponLevelText.Value = value;
        }
        public ReactiveField<string> WeaponLevelTextField => WeaponLevelText;
        public void Start()
        { 
            LevelTexts();
        }
        public string LevelTexts()
        {
            Text1 = "Стоимость улучшения: " + GettingPriceWeapon(levelWeapon) + "     увеличение скорости на " + Mathf.FloorToInt(((GettingMiningSpeedWeapon(levelWeapon) - GettingMiningSpeedWeapon(levelWeapon-1))/GettingMiningSpeedWeapon(levelWeapon-1)*100));
            Text2 = "%     увеличение объёма: "+ GettingCapacityWeapon(levelWeapon) + "     текущий уровень: " + levelWeapon;
            WeaponLevelTextProperty=Text1 + Text2;
            return WeaponLevelTextProperty;
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
                LevelTexts();
            }
        }
    }
}
