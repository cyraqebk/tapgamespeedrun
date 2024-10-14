using UnityEngine;
using UnityEngine.EventSystems;
using Core.Setting;
using TMPro;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UI.Animation;

namespace UI.Setting
{
    public class SettingVibration : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private LocalizedString _localizationString; // Если используете локализацию
        [SerializeField] private Settings settings; // Ссылка на настройки
        [SerializeField] private TMP_Text vibration; // Текст для отображения состояния вибрации
        [SerializeField] private ControlMenu controlMenu; // Ссылка на класс управления меню
        [SerializeField] private AnimationButton animationButton;
        private Vector3 originalScale;

        private void Start() 
        {
            originalScale = transform.localScale;
            UpdateVibrationText(); // Обновляем текст при старте
            LocalizationSettings.SelectedLocaleChanged += OnLocaleChanged; // Подписка на изменения языка
        }

        private void OnDestroy()
        {
            LocalizationSettings.SelectedLocaleChanged -= OnLocaleChanged; // Отписка от изменений языка
        }

        private void OnLocaleChanged(Locale locale)
        {
            UpdateVibrationText(); // Обновляем текст при изменении языка
        }

        private void UpdateVibrationText()
        {
            var currentLocale = LocalizationSettings.SelectedLocale; // Получаем текущую локаль
            if (currentLocale.Identifier.Code == "ru")
            {
                vibration.text = settings.vbr ? "Да" : "Нет"; // Текст на русском
            }
            else
            {
                vibration.text = settings.vbr ? "Yes" : "No"; // Текст на английском
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            settings._button.PlayOneShot(settings._button.clip);
            StartCoroutine(animationButton.AnimateButton(transform, originalScale));
            controlMenu.ControlVbr(); // Переключаем состояние вибрации
            UpdateVibrationText(); // Обновляем текст после изменения
        }
    }
}
