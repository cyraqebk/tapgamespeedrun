using UnityEngine;
using UnityEngine.EventSystems;
using UI.Animation;

namespace Core.Management
{
    public class SettingButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private StartGame startGame;
        [SerializeField] private AnimationButton animationButton;
        private Vector3 originalScale;
        private void Start() 
        {
            originalScale = transform.localScale;
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            StartCoroutine(animationButton.AnimateButton(transform, originalScale));
            startGame.Off(startGame.walletCanvasGroup, startGame.walletButtonImage);
            startGame.Off(startGame.tappingCanvasGroup, startGame.tappingButtonImage);
            startGame.On(startGame.settingsCanvasGroup, null);
            startGame.Off(startGame.managementCanvasGroup, null);
            startGame.Off(startGame.miningCanvasGroup, startGame.miningButtonImage);
        }
    }
}
