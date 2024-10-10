using UnityEngine;
using Core.ReactiveFields;
using Core.Json;
using System.Collections;

namespace Core.Wallet
{
    public class WalletAmount : MonoBehaviour
    {
        [SerializeField] private GameInitializer gameInitializer;
        [SerializeField] private ReactiveField<float> WalletCurrency = new ReactiveField<float>(0);
        public float WalletAmountProperty
        {
            get=>WalletCurrency.Value;
            set=>WalletCurrency.Value = value;
        }
        public ReactiveField<float> WalletField => WalletCurrency;
        private void Start() 
        {
            if (Memory.saves.ContainsKey("WalletAmountProperty"))
            {
                var loadedWalletAmountProperty  = new Load<float>("WalletAmountProperty");
                if (loadedWalletAmountProperty!=0)
                {
                    WalletAmountProperty = loadedWalletAmountProperty;
                }
            }
        }
        
    }
}
