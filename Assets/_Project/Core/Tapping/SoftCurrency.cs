using UnityEngine;
using Core.ReactiveFields;

namespace Core.Tappings
{
    public class SoftCurrency : MonoBehaviour
    {
        [SerializeField] private ReactiveField<int> currentCurrency = new ReactiveField<int>(0);
        public int CurrentAmount
        {
            get => currentCurrency.Value;
            set => currentCurrency.Value = value;
        }
        public ReactiveField<int> CurrencyField => currentCurrency;
    }
}

