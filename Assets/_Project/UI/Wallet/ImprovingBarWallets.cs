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
        [SerializeField] private TMP_Text UrText;


        private void OnEnable()
        {
            improvingBarWallet.WeaponLevelTextField.Changed += OnWeaponTextChanged;
            WeaponLevel.text = improvingBarWallet.WeaponLevelTextProperty;
            UrText.text="Текущий уровень: " + improvingBarWallet.levelWeaponProperty + "    Скорость: " + Mathf.Round((improvingBarWallet.GettingMiningSpeedWeapon(improvingBarWallet.levelWeaponProperty-1)) * 10f) / 10f;
        }

        private void OnDisable()
        {
            improvingBarWallet.WeaponLevelTextField.Changed -= OnWeaponTextChanged;
        }

        private void OnWeaponTextChanged(string oldValue, string newValue)
        {
            WeaponLevel.text=improvingBarWallet.WeaponLevelTextProperty;
            UrText.text="Текущий уровень: " + improvingBarWallet.levelWeaponProperty + "    Скорость: " + Mathf.Round((improvingBarWallet.GettingMiningSpeedWeapon(improvingBarWallet.levelWeaponProperty-1)) * 10f) / 10f;
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            improvingBarWallet.UpgradeLevel();
        }
    }
}
