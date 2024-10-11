using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;
using Core.Json;
using System.Collections;
using UnityEngine.EventSystems;
using Core.Tappings;
using Core.Wallet;
using UI.Wallet;

namespace Core.Management
{
    public class ClearJson : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private SoftCurrency softCurrency;
        [SerializeField] private LevelUpgrade levelUpgrade;
        [SerializeField] private PassiveIncome passiveIncome;
        [SerializeField] private WalletAmount walletAmount;
        [SerializeField] private ImprovingBarWallet improvingBarWallet;
        [SerializeField] private GameInitializer gameInitializer;
        public static void ClearSaves()
        {
            Memory.ClearSaves();
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            ClearSaves();
            ClearAll();
        }
        public void ClearAll()
        {
            // softCurrency.CurrentAmount = 0;
            // levelUpgrade.CurrenLevelProperty = 1;
            // levelUpgrade.levelTextAmount = "1";
            // levelUpgrade.levelTextAmount = levelUpgrade.GetUpgradeCost().ToString();
            // this.passiveIncome.MaximumValueWalletProperty = 1000;
            // this.passiveIncome.MiningSpeedProperty = 1;
            // walletAmount.WalletAmountProperty = 0;
            // improvingBarWallet.levelWeaponProperty =1;
            // improvingBarWallet.WeaponLevelTextProperty = "1";
            // localiText.Purpose();
        }

    }
}
