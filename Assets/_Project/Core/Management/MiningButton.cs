using UnityEngine;
using UnityEngine.EventSystems;
using UI.Animation;
using Core.Setting;

namespace Core.Management
{
    public class MiningButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private StartGame startGame;
        [SerializeField] private Settings settings;
        [SerializeField] private AnimationButton animationButton;
        private Vector3 originalScale;

        private void Start() 
        {
            originalScale = transform.localScale;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            settings._button.PlayOneShot(settings._button.clip);
            StartCoroutine(animationButton.AnimateButton(transform, originalScale));
            startGame.Off(startGame.walletCanvasGroup, startGame.walletButtonImage);
            startGame.Off(startGame.tappingCanvasGroup, startGame.tappingButtonImage);
            startGame.Off(startGame.settingsCanvasGroup, null);
            startGame.On(startGame.managementCanvasGroup, null);
            startGame.On(startGame.miningCanvasGroup, startGame.miningButtonImage);
        }
    }
}
