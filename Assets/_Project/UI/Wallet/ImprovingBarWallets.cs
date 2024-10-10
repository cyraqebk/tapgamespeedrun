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
        public void OnPointerClick(PointerEventData eventData)
        {
            // improvingBarWallet.UpgradeLevel();
        }
    }
}
