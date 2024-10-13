using UnityEngine;
using UnityEngine.EventSystems;
using UI.Animation;

namespace Core.Management
{
    public class MiningButton : MonoBehaviour, IPointerClickHandler
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
            if (startGame.miningCanvasGroup == null)
            {
                Debug.LogError("miningCanvasGroup is null");
                return;
            }
            StartCoroutine(animationButton.AnimateButton(transform, originalScale));
            startGame.Off(startGame.walletCanvasGroup);
            startGame.Off(startGame.tappingCanvasGroup);
            startGame.Off(startGame.settingsCanvasGroup);
            startGame.On(startGame.managementCanvasGroup);
            startGame.On(startGame.miningCanvasGroup);
        }
    }
}
