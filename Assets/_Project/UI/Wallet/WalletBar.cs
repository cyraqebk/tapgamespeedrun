using UnityEngine;
using Core.Wallet;
using UnityEngine.UI;


namespace UI.Wallet
{
    public class WalletBar : MonoBehaviour
    {
        [SerializeField] private Image Bar;
        [SerializeField] private PassiveIncome passiveIncome;
        [SerializeField] private WalletAmount walletAmount;
        private void OnEnable()
        {
            walletAmount.WalletField.Changed += SetFillAmount;
            Bar.fillAmount = Mathf.Clamp01(walletAmount.WalletAmountProperty/passiveIncome.MaximumValueWalletProperty);
        }

        private void OnDisable()
        {
            walletAmount.WalletField.Changed -= SetFillAmount;
        }
        public void SetFillAmount(float oldValue, float newValue)
        {
            Bar.fillAmount = walletAmount.WalletAmountProperty/passiveIncome.MaximumValueWalletProperty;
        }
    }
}
