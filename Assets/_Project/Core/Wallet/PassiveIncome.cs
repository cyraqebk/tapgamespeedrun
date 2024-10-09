using UnityEngine;
using System.Collections;
using System;
using Core.Json;


namespace Core.Wallet
{
    public class PassiveIncome : MonoBehaviour
    {
        [SerializeField] private GameInitializer gameInitializer;
        [SerializeField] private int MaximumValueWallet= 1000 ;
        [SerializeField] private float MiningSpeed = 1;
        [SerializeField] private WalletAmount walletAmount;
        private DateTime TimeWallet;
        private DateTime NewTimeWallet;
        public int MaximumValueWalletProperty
        {
            get=>MaximumValueWallet;
            set=>MaximumValueWallet = value;
        }
        public float MiningSpeedProperty
        {
            get=>MiningSpeed;
            set=>MiningSpeed = value;
        }
        public IEnumerator RepeatEverySecond()
        {
            while (true)
            {
                if (walletAmount.WalletAmountProperty + MiningSpeed < MaximumValueWallet)
                {
                    walletAmount.WalletAmountProperty += MiningSpeed;
                }
                else
                {
                    walletAmount.WalletAmountProperty = MaximumValueWallet;
                    break;
                }
                yield return new WaitForSeconds(1f);
            }
        }
        public void Start()
        {
            StartCoroutine(RepeatEverySecond());
            if (Memory.saves.ContainsKey("MaximumValueWallet"))
            {
                var loadedMaximumValueWallet  = new Load<int>("MaximumValueWallet");
                if (loadedMaximumValueWallet!=0)
                {
                    MaximumValueWallet = loadedMaximumValueWallet;
                }
            }
            if (Memory.saves.ContainsKey("MiningSpeed"))
            {
                var loadedMiningSpeed = new Load<float>("MiningSpeed");
                if (loadedMiningSpeed!=0)
                {
                    MiningSpeed = loadedMiningSpeed;
                }
            }
            if (Memory.saves.ContainsKey("TimeWallet"))
            {
                var loadedTimeWallet = new Load<DateTime>("TimeWallet");
                TimeWallet = loadedTimeWallet;
                NewTimeWallet = DateTime.Now;
                TimeSpan timeDifference = NewTimeWallet - TimeWallet;
                double secondsDifference = timeDifference.TotalSeconds;
                walletAmount.WalletAmountProperty += (int)secondsDifference * MiningSpeed;
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
            new Save("MaximumValueWallet", MaximumValueWallet);
            new Save("MiningSpeed", MiningSpeed);
            DateTime TimeWallet = DateTime.Now;
            new Save("TimeWallet", TimeWallet);
            yield return null;
        }
        private void OnSaveComplete()
        {
        }
    }
}
