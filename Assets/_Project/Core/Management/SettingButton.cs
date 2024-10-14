using UnityEngine;
using UnityEngine.EventSystems;
using UI.Animation;
using Core.Setting;

namespace Core.Management
{
    public class SettingButton : MonoBehaviour, IPointerClickHandler
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
            startGame.On(startGame.settingsCanvasGroup, null);
            startGame.Off(startGame.managementCanvasGroup, null);
            startGame.Off(startGame.miningCanvasGroup, startGame.miningButtonImage);
        }
    }
}
