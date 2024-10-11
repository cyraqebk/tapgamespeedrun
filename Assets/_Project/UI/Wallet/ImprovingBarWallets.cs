using UnityEngine;
using UnityEngine.EventSystems;
using Core.Wallet;
using TMPro;
using Core.Tappings;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.SmartFormat.Utilities;

namespace UI.Wallet
{
    public class ImprovingBarWallets : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private ImprovingBarWallet improvingBarWallet;
        [SerializeField] private TMP_Text _lvlText;
        [SerializeField] private TMP_Text _speedText;
        [SerializeField] private TMP_Text _priceText;
        [SerializeField] private TMP_Text _newspeed;
        [SerializeField] private TMP_Text _newvolume;

        private void OnEnable()
        {
            improvingBarWallet.Lvl.Changed += CurrencyText;
            LvlAndSpeed();
            NewFeatures();
        }

        private void OnDisable()
        {
            improvingBarWallet.Lvl.Changed -= CurrencyText;
        }

        private void CurrencyText(int oldValue, int newValue)
        {
            LvlAndSpeed();
            NewFeatures();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            improvingBarWallet.UpgradeLevel();
            LvlAndSpeed();
            NewFeatures();
        }

        private void LvlAndSpeed()
        {
            _lvlText.text = improvingBarWallet.Lvl.Value.ToString();
            _speedText.text = (Mathf.Round(improvingBarWallet.GettingMiningSpeedWeapon(improvingBarWallet.Lvl.Value) * 100f) / 100f).ToString();
        }

        private void NewFeatures()
        {
            _priceText.text = improvingBarWallet.GettingPriceWeapon(improvingBarWallet.Lvl.Value+1).ToString();
            _newspeed.text = (Mathf.Round(improvingBarWallet.GettingMiningSpeedWeapon(improvingBarWallet.Lvl.Value+1) * 100f) / 100f).ToString();
            _newvolume.text = improvingBarWallet.GettingCapacityWeapon(improvingBarWallet.Lvl.Value+1).ToString();
        }
    }
}
