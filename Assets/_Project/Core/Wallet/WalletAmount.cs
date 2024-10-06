using UnityEngine;
using Core.ReactiveFields;

namespace Core.Wallet
{
    public class WalletAmount : MonoBehaviour
    {
        [SerializeField] private ReactiveField<float> WalletCurrency = new ReactiveField<float>(0);
        public float WalletAmountProperty
        {
            get=>WalletCurrency.Value;
            set=>WalletCurrency.Value = value;
        }
        public ReactiveField<float> WalletField => WalletCurrency;
    }
}
