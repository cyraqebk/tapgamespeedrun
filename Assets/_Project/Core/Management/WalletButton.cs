using UnityEngine;
using UnityEngine.EventSystems;
using UI.Animation;
using UnityEngine.UI; // Добавлено для работы с компонентом Image
using Core.Setting;

namespace Core.Management
{
    public class WalletButton : MonoBehaviour, IPointerClickHandler
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

            // Обновление состояния канвасов и кнопок
            startGame.On(startGame.walletCanvasGroup, startGame.walletButtonImage); // Активируем канвас кошелька и меняем цвет кнопки
            startGame.Off(startGame.tappingCanvasGroup, startGame.tappingButtonImage); // Деактивируем канвас таппинга
            startGame.Off(startGame.settingsCanvasGroup, null); // Деактивируем канвас настроек
            startGame.On(startGame.managementCanvasGroup, null); // Активируем канвас управления
            startGame.Off(startGame.miningCanvasGroup, startGame.miningButtonImage); // Деактивируем канвас майнинга
        }
    }
}
