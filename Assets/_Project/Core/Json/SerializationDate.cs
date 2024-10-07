using UnityEngine;
using Core.Tappings;
using Core.Wallet;
using UI.Tappings;
using System;
namespace Core.Json
{
    public class SerializationDate : MonoBehaviour
    {
        [SerializeField] private ImprovingBarWallet improvingBarWallet;
        [SerializeField] private SoftCurrency softCurrency;
        [SerializeField] private WalletAmount walletAmount; 
        [SerializeField] private LevelUpgrade levelUpgrade;
        [SerializeField] private PassiveIncome passiveIncome;
        public int LevelWeapon => improvingBarWallet.levelWeaponProperty;
        public int CurrentCurrency => softCurrency.CurrentAmount;
        public float WalletCurrency => walletAmount.WalletAmountProperty;
        public int CurrentLevel => levelUpgrade.currenLevelProperty;
        public int MaximumValueWallet => passiveIncome.MaximumValueWalletProperty;
        public float MiningSpeed => passiveIncome.MiningSpeedProperty;
        public DateTime CurrentDateTime = DateTime.Now;
        public SaveData GetData()
        {
            return new SaveData
            {
                levelWeapon = LevelWeapon,
                currentCurrency = CurrentCurrency,
                walletCurrency = WalletCurrency,
                currenLevel = CurrentLevel,
                maximumValueWallet = MaximumValueWallet,
                miningSpeed = MiningSpeed,
                currentDateTime = CurrentDateTime
            };
        }
    }

    [System.Serializable]
    public class SaveData
    {
        public int levelWeapon;
        public int currentCurrency;
        public float walletCurrency;
        public int currenLevel;
        public int maximumValueWallet;
        public float miningSpeed;
        public DateTime currentDateTime;
    }
}

