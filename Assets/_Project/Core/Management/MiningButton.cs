using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.Management
{
    public class MiningButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private StartGame startGame;
        public void OnPointerClick(PointerEventData eventData)
        {
            startGame.Off(startGame.walletCanvasGroup);
            startGame.Off(startGame.tappingCanvasGroup);
            startGame.Off(startGame.settingsCanvasGroup);
            startGame.On(startGame.managementCanvasGroup);
            startGame.On(startGame.miningCanvasGroup);
        }
    }
}
