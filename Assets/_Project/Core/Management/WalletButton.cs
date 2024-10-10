using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.Management
{
    public class WalletButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private StartGame startGame;
        public void OnPointerClick(PointerEventData eventData)
        {
            startGame.On(startGame.walletCanvasGroup);
            startGame.Off(startGame.tappingCanvasGroup);
            startGame.Off(startGame.settingsCanvasGroup);
            startGame.On(startGame.managementCanvasGroup);
            startGame.Off(startGame.miningCanvasGroup);
        }
    }
}
