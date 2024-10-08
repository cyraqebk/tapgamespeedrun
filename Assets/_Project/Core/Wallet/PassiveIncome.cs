using UnityEngine;
using System.Collections;
using System;


namespace Core.Wallet
{
    public class PassiveIncome : MonoBehaviour
    {
        [SerializeField] private int MaximumValueWallet= 1000 ;
        [SerializeField] private float MiningSpeed = 1;
        [SerializeField] private WalletAmount walletAmount;
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
        public void Start()
        {
            StartCoroutine(RepeatEverySecond());
        }
        public IEnumerator RepeatEverySecond()
        {
            while (true)
            {
                if (walletAmount.WalletAmountProperty + MiningSpeed < MaximumValueWallet)
                {
                    Debug.Log("evry second");
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
    }
}
