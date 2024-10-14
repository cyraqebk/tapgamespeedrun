using UnityEngine;
using UnityEngine.EventSystems;
using UI.Animation;
using UnityEngine.UI; // Не забудьте добавить эту директиву для работы с UI

namespace Core.Management
{
    public class TappingButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private StartGame startGame; // Ссылка на скрипт StartGame
        [SerializeField] private AnimationButton animationButton; // Ссылка на анимацию
        private Vector3 originalScale;

        private void Start() 
        {
            originalScale = transform.localScale;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            StartCoroutine(animationButton.AnimateButton(transform, originalScale));

            // Вызываем методы Off и On для переключения канвасов и изменения цвета кнопок
            startGame.Off(startGame.walletCanvasGroup, startGame.walletButtonImage);
            startGame.On(startGame.tappingCanvasGroup, startGame.tappingButtonImage);
            startGame.Off(startGame.settingsCanvasGroup, null); // Если нет кнопки, можно передать null
            startGame.On(startGame.managementCanvasGroup, null); // Или добавьте нужные ссылки
            startGame.Off(startGame.miningCanvasGroup, startGame.miningButtonImage);
        }
    }
}
