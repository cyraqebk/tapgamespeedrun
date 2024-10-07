using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using Core.Tappings;
using Core.Wallet;
using System;

namespace Core.Json
{
    public class Serialization : MonoBehaviour
    {
        [SerializeField] private SerializationDate serializationDate;
        [SerializeField] private ImprovingBarWallet improvingBarWallet;
        [SerializeField] private SoftCurrency softCurrency;
        [SerializeField] private WalletAmount walletAmount; 
        [SerializeField] private LevelUpgrade levelUpgrade;
        [SerializeField] private PassiveIncome passiveIncome;
        public DateTime DeCurrentDateTime;
        private void Start() 
        {
            DeSerializeData();  
        }
        private void SerializeData()
        {
            var data = serializationDate.GetData();
            var Json = JsonConvert.SerializeObject(data);
            Debug.Log(Json);
            File.WriteAllText(Application.dataPath + "/savedata.json", Json); 
        }
        private void DeSerializeData()
        {
            var json = File.ReadAllText(Application.dataPath + "/savedata.json"); 
            var saveData = JsonConvert.DeserializeObject<SaveData>(json);
            levelUpgrade.currenLevelProperty = saveData.currenLevel;
            improvingBarWallet.levelWeaponProperty = saveData.levelWeapon;
            softCurrency.CurrentAmount = saveData.currentCurrency;
            walletAmount.WalletAmountProperty = saveData.walletCurrency;
            passiveIncome.MaximumValueWalletProperty = saveData.maximumValueWallet;
            passiveIncome.MiningSpeedProperty = saveData.miningSpeed;
            DeCurrentDateTime = DateTime.Now;
            walletAmount.WalletAmountProperty += ((float)(DeCurrentDateTime - saveData.currentDateTime).TotalSeconds) * saveData.miningSpeed;
            Debug.Log(saveData.levelWeapon);
        }
        private void OnApplicationQuit()
        {
            SerializeData();
        }
    }
}
