using UnityEngine;
using UnityEngine.EventSystems;
using Core.Setting;
using TMPro;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UI.Animation;

namespace UI.SettingUI
{
    public class SettingSound : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Settings settings;
        [SerializeField] private TMP_Text sound;
        [SerializeField] private ControlMenu controlMenu;
        [SerializeField] private AnimationButton animationButton;
        private Vector3 originalScale;
        private void Start() 
        {
            originalScale = transform.localScale;
            UpdateSoundText(); // Обновляем текст при старте
            LocalizationSettings.SelectedLocaleChanged += OnLocaleChanged; // Подписка на изменения языка
        }
        private void OnDestroy()
        {
            LocalizationSettings.SelectedLocaleChanged -= OnLocaleChanged; // Отписка от изменений языка
        }

        private void OnLocaleChanged(Locale locale)
        {
            UpdateSoundText(); // Обновляем текст при изменении языка
        }
        private void UpdateSoundText()
        {
            var currentLocale = LocalizationSettings.SelectedLocale; // Получаем текущую локаль
            if (currentLocale.Identifier.Code == "ru")
            {
                sound.text = settings.sound2 ? "Да" : "Нет"; // Текст на русском
            }
            else
            {
                sound.text = settings.sound2 ? "Yes" : "No"; // Текст на английском
            }
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            settings._button.PlayOneShot(settings._button.clip);
            StartCoroutine(animationButton.AnimateButton(transform, originalScale));
            controlMenu.ControlSound(); // Переключаем состояние звука
            UpdateSoundText(); // Обновляем текст после изменения
        }
    }
}
