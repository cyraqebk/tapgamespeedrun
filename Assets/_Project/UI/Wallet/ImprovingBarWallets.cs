using UnityEngine;
using UnityEngine.EventSystems;
using Core.Wallet;
using TMPro;
using Core.Tappings;

namespace UI.Wallet
{
    public class ImprovingBarWallets : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private ImprovingBarWallet improvingBarWallet;
        [SerializeField] private TMP_Text WeaponLevel;

        private void OnEnable()
        {
            improvingBarWallet.WeaponLevelTextField.Changed += OnWeaponTextChanged;
            WeaponLevel.text = improvingBarWallet.WeaponLevelTextProperty.ToString();
        }

        private void OnDisable()
        {
            improvingBarWallet.WeaponLevelTextField.Changed -= OnWeaponTextChanged;
        }

        private void OnWeaponTextChanged(string oldValue, string newValue)
        {
            // moneyText.text = newValue.ToString();
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            
        }
    }
}
