using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.Management
{
    public class SettingOffButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private StartGame startGame;
        public void OnPointerClick(PointerEventData eventData)
        {
            startGame.Off(startGame.walletCanvasGroup);
            startGame.On(startGame.tappingCanvasGroup);
            startGame.Off(startGame.settingsCanvasGroup);
            startGame.On(startGame.managementCanvasGroup);
            startGame.Off(startGame.miningCanvasGroup);
        }
    }
}
