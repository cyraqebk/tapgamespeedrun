using UnityEngine;
using UnityEngine.EventSystems;
using Core.Wallet;
using TMPro;
using Core.Tappings;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;

namespace UI.Wallet
{
    public class ImprovingBarWallets : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private ImprovingBarWallet improvingBarWallet;
        [SerializeField] private TMP_Text localizedText;


        private void OnEnable()
        {
            var localizedString = new LocalizedString("string", "WeaponUP");
            localizedString.Arguments = new object[] { improvingBarWallet.levelWeaponProperty, Mathf.Round((improvingBarWallet.GettingMiningSpeedWeapon(improvingBarWallet.levelWeaponProperty-1)) * 10f) / 10f};
            localizedString.StringChanged += (localizedValue) =>
            {
                localizedText.text = localizedValue;
            };
            improvingBarWallet.WeaponLevelTextField.Changed += OnWeaponTextChanged;
        }

        private void OnDisable()
        {
            improvingBarWallet.WeaponLevelTextField.Changed -= OnWeaponTextChanged;
        }

        private void OnWeaponTextChanged(string oldValue, string newValue)
        {
            var localizedString = new LocalizedString("string", "WeaponUP");
            localizedString.Arguments = new object[] { improvingBarWallet.levelWeaponProperty, Mathf.Round((improvingBarWallet.GettingMiningSpeedWeapon(improvingBarWallet.levelWeaponProperty-1)) * 10f) / 10f};
            localizedString.StringChanged += (localizedValue) =>
            {
                localizedText.text = localizedValue;
            };
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            improvingBarWallet.UpgradeLevel();
        }
    }
}
