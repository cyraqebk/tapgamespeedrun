using UnityEngine;
using Core.Wallet;
using TMPro;



namespace UI.Wallet
{
    public class WalletTextBar : MonoBehaviour
    {
        [SerializeField] private WalletAmount walletAmount;
        [SerializeField] private TMP_Text TextBar;
        [SerializeField] private ImprovingBarWallet improvingBarWallet;
        [SerializeField] private int capacity;

        
        private void OnEnable()
        {
            walletAmount.WalletField.Changed += SetFillAmount;
            TextBar.text=Mathf.FloorToInt(walletAmount.WalletAmountProperty).ToString();
        }

        private void OnDisable()
        {
            walletAmount.WalletField.Changed -= SetFillAmount;
        }
        public void SetFillAmount(float oldValue, float newValue)
        {
            capacity=improvingBarWallet.GettingCapacityWeapon(improvingBarWallet.levelWeaponProperty-1);
            TextBar.text=Mathf.FloorToInt(walletAmount.WalletAmountProperty).ToString()+" / "+capacity;
        }
    }
}
