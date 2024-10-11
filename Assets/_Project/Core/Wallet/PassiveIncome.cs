using UnityEngine;
using System.Collections;
using System;
using Core.Json;
using System.Threading.Tasks;


namespace Core.Wallet
{
    public class PassiveIncome : MonoBehaviour
    {
        [SerializeField] private GameInitializer _gameInitializer;
        [SerializeField] private int _maximumValueWallet= 1000 ;
        [SerializeField] private float _miningSpeed = 1;
        public float MiningSpeed => _miningSpeed;
        [SerializeField] public WalletAmount _walletAmount;
        public int MaximumValueWallet => _maximumValueWallet;
        private float _speedmls;
        private DateTime _timeWallet;
        private DateTime _newTimeWallet;
        private void Start()
        {
            StartCoroutine(AddingToWallet());
        }

        public IEnumerator AddingToWallet()
        {
            while (_walletAmount.WalletField.Value < _maximumValueWallet)
            {
                float speedmls = _miningSpeed * (100f / 1000f);
                _walletAmount.CurrencyIncrease(speedmls);
                if (_walletAmount.WalletField.Value > _maximumValueWallet)
                {
                    _walletAmount.WalletField.Value = _maximumValueWallet;
                }
                yield return new WaitForSeconds(0.1f);
            }
        }
        public void GetMaximumVolume(int meaning)
        {
            _maximumValueWallet = meaning;
        }

        public void GetSpeed(float meaning)
        {
            _miningSpeed = meaning;
        }
        public bool PassivImpruv(float meaning)
        {
            if (_walletAmount.WalletField.Value + meaning >1000)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
