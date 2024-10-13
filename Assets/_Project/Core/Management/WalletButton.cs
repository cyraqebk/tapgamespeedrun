using UnityEngine;
using UnityEngine.EventSystems;
using UI.Animation;

namespace Core.Management
{
    public class WalletButton : MonoBehaviour, IPointerClickHandler
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
            startGame.On(startGame.walletCanvasGroup);
            startGame.Off(startGame.tappingCanvasGroup);
            startGame.Off(startGame.settingsCanvasGroup);
            startGame.On(startGame.managementCanvasGroup);
            startGame.Off(startGame.miningCanvasGroup);
        }
    }
}
