using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.Management
{
    public class WalletButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private StartGame startGame;
        public void OnPointerClick(PointerEventData eventData)
        {
            startGame.Wallet.gameObject.SetActive(true);
            startGame.Tapping.gameObject.SetActive(false);
            startGame.Settings.gameObject.SetActive(false);
            startGame.Management.gameObject.SetActive(true);
        }
    }
}
