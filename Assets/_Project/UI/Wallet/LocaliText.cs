using UnityEngine;
using Core.Wallet;
using TMPro;


namespace UI.Wallet
{
    public class LocaliText : MonoBehaviour
    {
        [SerializeField] ImprovingBarWallet improvingBarWallet;
        [SerializeField] private TMP_Text _levelText;
        [SerializeField] private TMP_Text _speedText;
        [SerializeField] private TMP_Text _priceText;
        [SerializeField] private TMP_Text _percentSpeedText;
        [SerializeField] private TMP_Text _volumeText;

        private int level;
        private float _speed;
        private int price;
        private int percentSpeed;
        private int _volume;
        private void Start() 
        {
            Purpose();
        }
        private void RecordText()
        {
            _levelText.text = level.ToString();
            _speedText.text = _speed.ToString();
            _priceText.text = price.ToString();
            _percentSpeedText.text = percentSpeed.ToString() + " %";
            _volumeText.text = _volume.ToString();
        }
        public void Purpose()
        {
            level = improvingBarWallet.levelWeaponProperty;
            _speed = Mathf.Round(improvingBarWallet.GettingMiningSpeedWeapon(improvingBarWallet.levelWeaponProperty - 1) * 100f)/100f;
            price = improvingBarWallet.GettingPriceWeapon(improvingBarWallet.levelWeaponProperty);
            percentSpeed = Mathf.FloorToInt(((improvingBarWallet.GettingMiningSpeedWeapon(improvingBarWallet.levelWeaponProperty) - improvingBarWallet.GettingMiningSpeedWeapon(improvingBarWallet.levelWeaponProperty-1))/improvingBarWallet.GettingMiningSpeedWeapon(improvingBarWallet.levelWeaponProperty-1)*100));
            _volume = improvingBarWallet.GettingCapacityWeapon(improvingBarWallet.levelWeaponProperty);
            RecordText();
        }
        private void OnEnable()
        {
            improvingBarWallet.Changed+=Purpose;
        }
        private void OnDisable()
        {
            improvingBarWallet.Changed-=Purpose;
        }
    }
}
