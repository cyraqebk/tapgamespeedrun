using UnityEngine;
using Core.Wallet;
using TMPro;



namespace UI.Wallet
{
    public class WalletTextBar : MonoBehaviour
    {
        [SerializeField] private WalletAmount walletAmount;
        [SerializeField] private TMP_Text TextBar;
        private void OnEnable()
        {
            walletAmount.WalletField.Changed += SetFillAmount;
            TextBar.text=walletAmount.WalletAmountProperty.ToString();
        }

        private void OnDisable()
        {
            walletAmount.WalletField.Changed -= SetFillAmount;
        }
        public void SetFillAmount(float oldValue, float newValue)
        {
            TextBar.text=walletAmount.WalletAmountProperty.ToString();
        }
    }
}
