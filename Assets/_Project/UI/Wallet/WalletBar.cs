using UnityEngine;
using Core.Wallet;
using UnityEngine.UI;


namespace UI.Wallet
{
    public class WalletBar : MonoBehaviour
    {
        [SerializeField] private Image _bar;
        [SerializeField] private PassiveIncome _passiveIncome;
        [SerializeField] private WalletAmount _walletAmount;
        private void OnEnable()
        {
            _walletAmount.WalletField.Changed += SetFillAmount;
            _bar.fillAmount = (int)Mathf.Floor(_walletAmount.WalletField.Value/_passiveIncome.MaximumValueWallet);
        }

        private void OnDisable()
        {
            _walletAmount.WalletField.Changed -= SetFillAmount;
        }
        public void SetFillAmount(float oldValue, float newValue)
        {
            _bar.fillAmount = _walletAmount.WalletField.Value/_passiveIncome.MaximumValueWallet;
        }
    }
}
