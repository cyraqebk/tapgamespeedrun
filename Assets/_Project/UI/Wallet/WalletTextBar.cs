using UnityEngine;
using Core.Wallet;
using TMPro;



namespace UI.Wallet
{
    public class WalletTextBar : MonoBehaviour
    {
        [SerializeField] private WalletAmount _walletAmount;
        [SerializeField] private TMP_Text _extBar;
        [SerializeField] private ImprovingBarWallet _improvingBarWallet;
        [SerializeField] private PassiveIncome _passiveIncome;

        
        private void OnEnable()
        {
            _walletAmount.WalletField.Changed += SetFillAmount;
            _extBar.text=Mathf.FloorToInt(_walletAmount.WalletField.Value).ToString()+" / "+_passiveIncome.MaximumValueWallet;
        }

        private void OnDisable()
        {
            _walletAmount.WalletField.Changed -= SetFillAmount;
        }
        public void SetFillAmount(float oldValue, float newValue)
        {
            _extBar.text=Mathf.FloorToInt(_walletAmount.WalletField.Value).ToString()+" / "+_passiveIncome.MaximumValueWallet;
        }
    }
}
