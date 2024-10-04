using UnityEngine;
using System.Collections;


namespace Core.Wallet
{
    public class PassiveIncome : MonoBehaviour
    {
        [SerializeField] private int MaximumValueWallet= 1000 ;
        [SerializeField] private int MiningSpeed = 1;
        [SerializeField] private WalletAmount walletAmount;
        public int MaximumValueWalletProperty
        {
            get=>MaximumValueWallet;
            set=>MaximumValueWallet = value;
        }
        void Start()
        {
            StartCoroutine(RepeatEverySecond());
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
    }
}
