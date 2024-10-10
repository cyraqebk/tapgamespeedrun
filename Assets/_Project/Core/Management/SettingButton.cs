using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.Management
{
    public class SettingButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private StartGame startGame;
        public void OnPointerClick(PointerEventData eventData)
        {
            startGame.Off(startGame.walletCanvasGroup);
            startGame.Off(startGame.tappingCanvasGroup);
            startGame.On(startGame.settingsCanvasGroup);
            startGame.Off(startGame.managementCanvasGroup);
            startGame.Off(startGame.miningCanvasGroup);
        }
    }
}
